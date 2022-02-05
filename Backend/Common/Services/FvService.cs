using Common.Models.ShopModels;
using FSharp.Data.Runtime.BaseTypes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using OpenHtmlToPdf;
using System;
using System.IO;
using System.Linq;
using System.Text;
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
                .Include(c => c.Carrier)
                .SingleAsync();
            var settings = await _context.ShopSettings.SingleAsync();

            DateTimeOffset d = order.Date;
            html = html.Replace("$$fvNumber$$", d.ToUnixTimeSeconds().ToString());
            html = html.Replace("$$customerFullName$$", order.Customer.Name + " " + order.Customer.Surname);
            html = html.Replace("$$dateOfOrder$$", order.Date.ToString("dd MM yyyy"));
            html = html.Replace("$$nip$$", order.Nip != null ? "<span class=\"font-bolder\">NIP:</span>" + order.Nip + "<br>" : "");
            html = html.Replace("$$customerPhone$$", order.CustomerPhoneNumber);
            html = html.Replace("$$customerEmail$$", order.CustomerEmail);
            html = html.Replace("$$totalVat$$", (order.PriceTotal * 0.23).ToString());
            html = html.Replace("$$totalNetto$$", (order.PriceTotal * 0.77).ToString());
            html = html.Replace("$$totalBrutto$$", order.PriceTotal.ToString());
            html = html.Replace("$$customerStreet$$", order.BillingAddressStreet == null ? order.DeliveryAddressStreet : order.BillingAddressStreet);
            html = html.Replace("$$customerPostal$$", order.BillingAddressPostal == null ? order.DeliveryAddressPostal : order.DeliveryAddressPostal);
            html = html.Replace("$$customerCity$$", order.BillingAddressCity == null ? order.DeliveryAddressCity : order.BillingAddressCity);
            html = html.Replace("$$customerCountry$$", order.BillingAddressCountry == null ? order.DeliveryAddressCountry : order.BillingAddressCountry);
            html = html.Replace("$$shopName$$", settings.ShopName);
            html = html.Replace("$$shopAddress$$", settings.ShopAddress);
            html = html.Replace("$$shopEmail$$", settings.ShopEmail);
            html = html.Replace("$$shopPhone$$", settings.ShopPhone);
            html = html.Replace("$$shopNip$$", "<span class=\"font-bolder\">NIP:</span>" + settings.ShopNip + "<br>");
            html = html.Replace("$$content$$", GetHtmlTable(order));
            return Pdf
                .From(html)
                .OfSize(PaperSize.A4)
                .WithGlobalSetting("web.defaultEncoding", "utf-8")
                .WithoutOutline()
                .Comressed()
                .Content();
        }

        private string GetHtmlTable(Order order)
        {
            var result = new StringBuilder();
            result.Append("<table class=\"order-table\">");
            //headers
            result.Append("<tr class=\"table-main\">");
            result.Append("<td>No</td>");
            result.Append("<td>Identifier</td>");
            result.Append("<td>Product name</td>");
            result.Append("<td>Quantity</td>");
            result.Append("<td>VAT</td>");
            result.Append("<td>Netto Price</td>");
            result.Append("<td>Brutto Price</td>");
            result.Append("</tr>");
            var iter = 1;
            foreach (var op in order.OrdersProducts)
            {
                result.Append("<tr class=\"table-product\">");
                result.Append("<td>" + iter.ToString() + "</td>");
                result.Append("<td>" + op.ProductId + "</td>");
                result.Append("<td>" + op.Product.Name + "</td>");
                result.Append("<td>" + op.ProductQuantity + "</td>");
                result.Append("<td>" + Math.Round((op.Product.BruttoPrice * 0.23), 2).ToString() + "$</td>");
                result.Append("<td>" + Math.Round((op.Product.BruttoPrice * 0.77), 2).ToString() + "$</td>");
                result.Append("<td>" + Math.Round((op.Product.BruttoPrice), 2).ToString() + "$</td>");
                result.Append("</tr>");
                iter++;
            }

            result.Append("</table>");

            return result.ToString();
        }
    }
}
