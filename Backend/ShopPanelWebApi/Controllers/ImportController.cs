using System.Collections.Generic;
using Common.Models.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Models.ShopPanelModels;
using ShopPanelWebApi.Repositories;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ImportController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("{tableTypes}")]
        public async Task<ActionResult> ImportDataFromFile(IFormFile file, TableType tableTypes)
        {
            if (file.Length > 0)
            {
                var fileExtension = file.FileName.Split(".").Last();

                if (fileExtension == "json")
                {
                    switch (tableTypes)
                    {
                        case TableType.employees:
                            var employeeRepository = new FileRepository<Employee>(new List<Employee>());
                            var employeeList = await employeeRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(employeeList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.employeesProfiles:
                            var employeesProfilesRepository = new FileRepository<EmployeesProfiles>(new List<EmployeesProfiles>());
                            var employeesProfilesList = await employeesProfilesRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(employeesProfilesList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.profiles:
                            var profileRepository = new FileRepository<Profile>(new List<Profile>());
                            var profileList = await profileRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(profileList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.customers:
                            var customerRepository = new FileRepository<Customer>(new List<Customer>());
                            var customerList = await customerRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(customerList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.statuses:
                            var statusRepository = new FileRepository<Status>(new List<Status>());
                            var statusList = await statusRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(statusList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.orders:
                            var orderRepository = new FileRepository<Order>(new List<Order>());
                            var orderList = await orderRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(orderList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.ordersProducts:
                            var ordersProductsRepository = new FileRepository<OrdersProducts>(new List<OrdersProducts>());
                            var ordersProductsList = await ordersProductsRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(ordersProductsList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.customrFavouritesProducts:
                            var customerFavouritesProductsRepository = new FileRepository<CustomerFavouritesProducts>(new List<CustomerFavouritesProducts>());
                            var customerFavouritesProductsList = await customerFavouritesProductsRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(customerFavouritesProductsList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.ratings:
                            var ratingRepository = new FileRepository<Rating>(new List<Rating>());
                            var ratingList = await ratingRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(ratingList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.comments:
                            var commentRepository = new FileRepository<Comment>(new List<Comment>());
                            var commentList = await commentRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(commentList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.tags:
                            var tagRepository = new FileRepository<Tag>(new List<Tag>());
                            var tagList = await tagRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(tagList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.productTags:
                            var productsTagsRepository = new FileRepository<ProductsTags>(new List<ProductsTags>());
                            var productsTagsList = await productsTagsRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(productsTagsList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.products:
                            var productsRepository = new FileRepository<Product>(new List<Product>());
                            var productsList = await productsRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(productsList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.productsPayments:
                            var productsPaymentsRepository = new FileRepository<ProductsPayments>(new List<ProductsPayments>());
                            var productsPaymentsList = await productsPaymentsRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(productsPaymentsList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.paymentTypes:
                            var paymentTypeRepository = new FileRepository<PaymentType>(new List<PaymentType>());
                            var paymentTypeList = await paymentTypeRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(paymentTypeList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.carriers:
                            var carrierRepository = new FileRepository<Carrier>(new List<Carrier>());
                            var carrierList = await carrierRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(carrierList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.productsCarriers:
                            var productsCarriersRepository = new FileRepository<ProductsCarriers>(new List<ProductsCarriers>());
                            var productsCarriersList = await productsCarriersRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(productsCarriersList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.taxes:
                            var taxRepository = new FileRepository<Tax>(new List<Tax>());
                            var taxList = await taxRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(taxList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.categories:
                            var categoryRepository = new FileRepository<Category>(new List<Category>());
                            var categoryList = await categoryRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(categoryList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.productsVariants:
                            var productVariantRepository = new FileRepository<ProductVariant>(new List<ProductVariant>());
                            var productVariantsList = await productVariantRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(productVariantsList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.productsVariantsPhotos:
                            var productsVariantsPhotosRepository = new FileRepository<ProductsVariantsPhotos>(new List<ProductsVariantsPhotos>());
                            var productsVariantsPhotosList = await productsVariantsPhotosRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(productsVariantsPhotosList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.photos:
                            var photoRepository = new FileRepository<Photo>(new List<Photo>());
                            var photoList = await photoRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(photoList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.productColors:
                            var productColorRepository = new FileRepository<ProductColor>(new List<ProductColor>());
                            var productColorsList = await productColorRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(productColorsList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.productDiemensions:
                            var productDimensionRepository = new FileRepository<ProductDimensions>(new List<ProductDimensions>());
                            var productDimensionsList = await productDimensionRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(productDimensionsList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.homeLists:
                            var homeListRepository = new FileRepository<HomeList>(new List<HomeList>());
                            var homeListsList = await homeListRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(homeListsList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        case TableType.homeProductsLists:
                            var homeProductsListsRepository = new FileRepository<HomeProductsLists>(new List<HomeProductsLists>());
                            var homeProductsListsList = await homeProductsListsRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(homeProductsListsList);

                            await _context.SaveChangesAsync();
                            return Ok();

                        default:
                            return new UnsupportedMediaTypeResult();
                    }
                }
                else
                    return new UnsupportedMediaTypeResult();
            }
            else
                return new UnsupportedMediaTypeResult();
        }
    }
}
