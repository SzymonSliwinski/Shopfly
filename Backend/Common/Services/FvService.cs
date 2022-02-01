using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using OpenHtmlToPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Services
{
    public class FvService
    {
        private readonly AppDbContext _context;
        private string _fvPath;
        public FvService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _fvPath = env.ContentRootPath;
        }

        public async Task<byte[]> GetFVForOrder(int orderId)
        {
            var html = File.ReadAllText(_fvPath + "\\..\\Common\\Assets\\fv.html");
            var order = await _context.Orders
                .AsQueryable()
                .Where(c => c.Id == orderId)
                .Include(c => c.OrdersProducts)
                .ThenInclude(c => c.Product)
                .Include(c => c.Customer)
                .SingleAsync();
            DateTimeOffset d = order.Date;
            html = html.Replace("$$fvNumber$$", d.ToUnixTimeSeconds().ToString());
            html = html.Replace("$$customerFullName$$", order.Customer.Name + " " + order.Customer.Surname);
            html = html.Replace("$$dateOfOrder$$", order.Date.ToString("dd MM yyyy"));
            html = html.Replace("$$nip$$", order.Nip != null ? "<span class=\"bolded-font\">NIP:</span>" + order.Nip + "<br>" : "");
            html = html.Replace("$$customerPhone$$", order.CustomerPhoneNumber);
            html = html.Replace("$$customerEmail$$", order.CustomerEmail);
            html = html.Replace("$$totalVat$$", (order.PriceTotal * 0.23).ToString());
            html = html.Replace("$$totalNetto$$", (order.PriceTotal * 0.77).ToString());
            html = html.Replace("$$totalBrutto$$", order.PriceTotal.ToString());
            html = html.Replace("$$customerStreet$$", order.BillingAddressStreet == null ? order.DeliveryAddressStreet : order.BillingAddressStreet);
            html = html.Replace("$$customerPostal$$", order.BillingAddressPostal == null ? order.DeliveryAddressPostal : order.DeliveryAddressPostal);
            html = html.Replace("$$customerCity$$", order.BillingAddressCity == null ? order.DeliveryAddressCity : order.BillingAddressCity);
            html = html.Replace("$$customerCountry$$", order.BillingAddressCountry == null ? order.DeliveryAddressCountry : order.BillingAddressCountry);


            return Pdf
                .From(html)
                .OfSize(PaperSize.A4)
                .WithGlobalSetting("web.defaultEncoding", "utf-8")
                .WithoutOutline()
                .Comressed()
                .Content();
        }
    }
}
