using System;
using System.Collections.Generic;
using System.IO;
using Bogus;
using Bogus.Extensions;
using GenerateRandomData.Models.ApiModels;
using GenerateRandomData.Models.ShopModels;
using GenerateRandomData.Models.ShopPanelModels;
using GenerateRandomData.Models.Token;

namespace GenerateRandomData
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.Directory.CreateDirectory(@"../../generatedJson");
            string savePath = @"../../generatedJson/";
            string dateFile = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            Console.Write("Enter number of generated positions: ");
            int numberOfPositions = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number of positions in each file = " + numberOfPositions);

            // wywołanie funkcji generujących dane:
            GenerateEmployee(numberOfPositions, true, savePath, dateFile);
            GenerateEmployeesProfiles(numberOfPositions, true, savePath, dateFile);
            GenerateProfile(numberOfPositions, true, savePath, dateFile);

            GenerateCarrier(numberOfPositions, true, savePath, dateFile);
            GenerateCategory(numberOfPositions, true, savePath, dateFile);
            GenerateComment(numberOfPositions, true, savePath, dateFile);
            GenerateCustomer(numberOfPositions, true, savePath, dateFile);
            GenerateCustomerFavouritesProducts(numberOfPositions, true, savePath, dateFile);
            GenerateOrder(numberOfPositions, true, savePath, dateFile);
            GenerateOrdersProducts(numberOfPositions, true, savePath, dateFile);
            GeneratePaymentType(numberOfPositions, true, savePath, dateFile);
            GeneratePhoto(numberOfPositions, true, savePath, dateFile);
            GenerateProduct(numberOfPositions, true, savePath, dateFile);
            GenerateProductColor(numberOfPositions, true, savePath, dateFile);
            GenerateProductDimensions(numberOfPositions, true, savePath, dateFile);
            GenerateProductsCarriers(numberOfPositions, true, savePath, dateFile);
            GenerateProductsPayments(numberOfPositions, true, savePath, dateFile);
            GenerateProductsTags(numberOfPositions, true, savePath, dateFile);
            GenerateProductsVariantsPhotos(numberOfPositions, true, savePath, dateFile);
            GenerateProductVariant(numberOfPositions, true, savePath, dateFile);
            GenerateRating(numberOfPositions, true, savePath, dateFile);
            GenerateStatus(numberOfPositions, true, savePath, dateFile);
            GenerateTag(numberOfPositions, true, savePath, dateFile);
            GenerateTax(numberOfPositions, true, savePath, dateFile);
            GenerateHomeList(numberOfPositions, true, savePath, dateFile);
            GenerateHomeProductsList(numberOfPositions, true, savePath, dateFile);

            GenerateApiAccessKey(numberOfPositions, true, savePath, dateFile);
            GenerateApiKeysTablesMethods(numberOfPositions, true, savePath, dateFile);

            GenerateToken(numberOfPositions, true, savePath, dateFile);
        }

        // Shop Panel Models ------------------------
        static Faker<Employee> GenerateEmployee(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var index = 1;
            var employeeData = new Faker<Employee>("pl")
                .StrictMode(false)
                .RuleFor(e => e.Name, e => e.Name.FirstName().ClampLength(1, 50))
                .RuleFor(e => e.Surname, e => e.Name.LastName().ClampLength(1, 50))
                .RuleFor(e => e.Email, e => e.Internet.Email().ClampLength(1, 25) + index++)
                .RuleFor(e => e.IsActive, e => e.Random.Bool())
                .RuleFor(e => e.Password, e => e.Internet.Password(12, false))
                .RuleFor(e => e.IsRoot, e => e.Random.Bool());

            if (saveToFile)
            {
                // generowanie danych:
                List<Employee> myEmployee = employeeData.Generate(numberOfPositions);
                // zapis do pliku:
                string fileName = "1_employee_" + dateFile + ".json";

                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myEmployee);
                }

                Console.WriteLine("file " + fileName + " generated");
            }

            return employeeData;
        }

        static Faker<EmployeesProfiles> GenerateEmployeesProfiles(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var index = 1;
            var employeesProfilesData = new Faker<EmployeesProfiles>("pl")
                .RuleFor(ep => ep.EmployeeId, ep => ep.Random.Int(index, index++))
                .RuleFor(ep => ep.ProfileId, ep => ep.Random.Int(1, numberOfPositions));


            if (saveToFile)
            {
                List<EmployeesProfiles> myEmployeesProfiles = employeesProfilesData.Generate(numberOfPositions);

                string fileName = "3_employeesProfiles_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myEmployeesProfiles);
                }

                Console.WriteLine("file " + fileName + " generated");
            }

            return employeesProfilesData;
        }

        static Faker<Profile> GenerateProfile(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var index = 1;
            // ustawienie właściwości:
            var profileData = new Faker<Profile>("pl")
                .RuleFor(p => p.Name, p => p.Random.Word().ClampLength(1, 25) + index++)
                .RuleFor(p => p.HasAccessToOrders, p => p.Random.Bool())
                .RuleFor(p => p.HasAccessToImports, p => p.Random.Bool())
                .RuleFor(p => p.HasAccessToProducts, p => p.Random.Bool())
                .RuleFor(p => p.HasAccessToCustomers, p => p.Random.Bool())
                .RuleFor(p => p.HasAccessToCharts, p => p.Random.Bool())
                .RuleFor(p => p.HasAccessToSettings, p => p.Random.Bool())
                .RuleFor(p => p.HasAccessToApi, p => p.Random.Bool())
                .RuleFor(p => p.HasAccessToEmployees, p => p.Random.Bool());

            // zapis do pliku:
            if (saveToFile)
            {
                List<Profile> myProfile = profileData.Generate(numberOfPositions);

                string fileName = "2_profile_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myProfile);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return profileData;
        }

        // Shop Models -------------------------------
        static Faker<Carrier> GenerateCarrier(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var index = 1;
            // ustawienie właściwości:
            var carrierData = new Faker<Carrier>("pl")
                .RuleFor(c => c.Cost, c => float.Parse(c.Commerce.Price()))
                .RuleFor(c => c.Name, c => c.Random.Word().ClampLength(1, 25) + index)
                .RuleFor(c => c.Logo, c => c.System.FilePath().ClampLength(1, 45) + index++)
                .RuleFor(c => c.DeliveryDaysMinimum, c => c.Random.Int(1, 30))
                .RuleFor(c => c.DeliveryDaysMaximum, c => c.Random.Int(1, 60))
                .RuleFor(c => c.IsActive, c => c.Random.Bool());

            // zapis do pliku:
            if (saveToFile)
            {
                List<Carrier> myCarrier = carrierData.Generate(numberOfPositions);

                string fileName = "12_carrier_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myCarrier);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return carrierData;
        }

        static Faker<Category> GenerateCategory(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var count = 1;
            // ustawienie właściwości:
            var categoryData = new Faker<Category>("pl")
                .RuleFor(c => c.Name, c => c.Random.Word().ClampLength(1, 30))
                .RuleFor(c => c.IsRoot, c => c.Random.Bool())
                .RuleFor(c => c.ParentCategoryId, c => c.Random?.Int(1, count++))
                .RuleFor(c => c.Position, c => c.Random.Int(1, numberOfPositions));

            // zapis do pliku:
            if (saveToFile)
            {
                List<Category> myCategory = categoryData.Generate(numberOfPositions);

                string fileName = "category_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myCategory);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return categoryData;
        }

        static Faker<Comment> GenerateComment(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var commentData = new Faker<Comment>("pl")
                .RuleFor(c => c.CustomerId, c => c.Random.Int(1, numberOfPositions))
                .RuleFor(c => c.ProductId, c => c.Random.Int(1, numberOfPositions))
                .RuleFor(c => c.Content, c => c.Lorem.Text().ClampLength(1, 200))
                .RuleFor(c => c.CreateDate, c => c.Date.Past(3));


            // zapis do pliku:
            if (saveToFile)
            {
                List<Comment> myComment = commentData.Generate(numberOfPositions);

                string fileName = "comment_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myComment);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return commentData;
        }

        static Faker<Customer> GenerateCustomer(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var index = 1;
            // ustawienie właściwości:
            var customerData = new Faker<Customer>("pl")
                .RuleFor(c => c.Name, c => c.Name.FirstName().ClampLength(1, 50))
                .RuleFor(c => c.Surname, c => c.Name.LastName().ClampLength(1, 50))
                .RuleFor(c => c.PhoneNumber, c => c.Phone.PhoneNumber("#########").ClampLength(1, 15) + index)
                .RuleFor(c => c.Email, c => c.Internet.Email().ClampLength(1, 45) + index++)
                .RuleFor(c => c.IsNewsletterSubscribed, c => c.Random.Bool())
                .RuleFor(c => c.CreateDate, c => c.Date.Past(3))
                .RuleFor(c => c.LastLoginDate, c => c.Date.Recent(365))
                .RuleFor(c => c.Password, c => c.Internet.Password(12))
                .RuleFor(c => c.IsActive, c => c.Random.Bool());

            // zapis do pliku:
            if (saveToFile)
            {
                List<Customer> myComment = customerData.Generate(numberOfPositions);

                string fileName = "10_customer_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myComment);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return customerData;
        }

        static Faker<CustomerFavouritesProducts> GenerateCustomerFavouritesProducts(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var customerFavouritesProductsData = new Faker<CustomerFavouritesProducts>("pl")
                .RuleFor(cfp => cfp.CustomerId, cfp => cfp.Random.Int(1, numberOfPositions))
                .RuleFor(cfp => cfp.ProductId, cfp => cfp.Random.Int(1, numberOfPositions));

            // zapis do pliku:
            if (saveToFile)
            {
                List<CustomerFavouritesProducts> myCustomerFavouritesProducts = customerFavouritesProductsData.Generate(numberOfPositions);

                string fileName = "customerFavouritesProducts_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myCustomerFavouritesProducts);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return customerFavouritesProductsData;
        }

        static Faker<Order> GenerateOrder(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var orderData = new Faker<Order>("pl")
                .RuleFor(o => o.PaymentTypeId, o => o.Random.Int(1, numberOfPositions))
                .RuleFor(o => o.StatusId, o => o.Random.Int(1, numberOfPositions))
                .RuleFor(o => o.CarrierId, o => o.Random.Int(1, numberOfPositions))
                .RuleFor(o => o.CustomerId, o => o.Random.Int(1, numberOfPositions))
                .RuleFor(o => o.PriceTotal, o => float.Parse(o.Commerce.Price()))
                .RuleFor(o => o.Date, o => o.Date.Recent(365))
                .RuleFor(o => o.AdditionalDescription, o => o.Lorem.Text().ClampLength(1, 200))
                .RuleFor(o => o.IsActive, o => o.Random.Bool())
                .RuleFor(o => o.CompleteDate, o => o.Date.Recent(365))

                .RuleFor(o => o.DeliveryAddressStreet, o => o.Address.StreetName().ClampLength(1, 30))
                .RuleFor(o => o.DeliveryAddressPostal, o => o.Address.ZipCode().ClampLength(1, 30))
                .RuleFor(o => o.DeliveryAddressCity, o => o.Address.City().ClampLength(1, 30))
                .RuleFor(o => o.DeliveryAddressCountry, o => o.Address.Country().ClampLength(1, 30))

                .RuleFor(o => o.BillingAddressStreet, o => o.Address.StreetName().ClampLength(1, 30))
                .RuleFor(o => o.BillingAddressPostal, o => o.Address.ZipCode().ClampLength(1, 30))
                .RuleFor(o => o.BillingAddressCity, o => o.Address.City().ClampLength(1, 30))
                .RuleFor(o => o.BillingAddressCountry, o => o.Address.Country().ClampLength(1, 30))

                .RuleFor(o => o.Nip, o => o.Phone.PhoneNumber("###-###-##-##").ClampLength(1, 10))
                .RuleFor(o => o.CompanyName, o => o.Company.CompanyName().ClampLength(1, 10))
                .RuleFor(o => o.CustomerPhoneNumber, o => o.Phone.PhoneNumber("#########").ClampLength(1, 10))
                .RuleFor(o => o.CustomerEmail, o => o.Internet.Email().ClampLength(1, 10));

            // zapis do pliku:
            if (saveToFile)
            {
                List<Order> myOrder = orderData.Generate(numberOfPositions);

                string fileName = "order_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myOrder);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return orderData;
        }

        static Faker<OrdersProducts> GenerateOrdersProducts(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var ordersProductsData = new Faker<OrdersProducts>("pl")
                .RuleFor(op => op.OrderId, op => op.Random.Int(1, numberOfPositions))
                .RuleFor(op => op.ProductId, op => op.Random.Int(1, numberOfPositions))
                .RuleFor(op => op.ProductQuantity, op => op.Random.Float(1F, float.MaxValue));

            // zapis do pliku:
            if (saveToFile)
            {
                List<OrdersProducts> myOrdersProducts = ordersProductsData.Generate(numberOfPositions);

                string fileName = "ordersProducts_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myOrdersProducts);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return ordersProductsData;
        }

        static Faker<PaymentType> GeneratePaymentType(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var paymentTypeData = new Faker<PaymentType>("pl")
                .RuleFor(pt => pt.Name, pt => pt.Random.Word().ClampLength(1, 30))
                .RuleFor(pt => pt.Icon, pt => pt.System.FilePath().ClampLength(1, 50))
                .RuleFor(pt => pt.IsActive, pt => pt.Random.Bool());

            // zapis do pliku:
            if (saveToFile)
            {
                List<PaymentType> myPaymentType = paymentTypeData.Generate(numberOfPositions);

                string fileName = "11_paymentType_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myPaymentType);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return paymentTypeData;
        }

        static Faker<Photo> GeneratePhoto(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var index = 1;
            // ustawienie właściwości:
            var photoData = new Faker<Photo>("pl")
                .RuleFor(p => p.IsCover, p => p.Random.Bool())
                .RuleFor(p => p.Path, p => p.System.FilePath().ClampLength(1, 45) + index++);

            // zapis do pliku:
            if (saveToFile)
            {
                List<Photo> myPhoto = photoData.Generate(numberOfPositions);

                string fileName = "7_photo_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myPhoto);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return photoData;
        }

        static Faker<Product> GenerateProduct(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var productData = new Faker<Product>("pl")
                .RuleFor(p => p.CategoryId, p => p.Random.Int(1, numberOfPositions))
                .RuleFor(p => p.Name, p => p.Random.Word().ClampLength(1, 30))
                .RuleFor(p => p.TaxId, p => p.Random.Int(1, numberOfPositions))
                .RuleFor(p => p.IsLowStock, p => p.Random.Bool())
                .RuleFor(p => p.AdditionalShippingCost, p => float.Parse(p.Commerce.Price(5, 40)))
                .RuleFor(p => p.NettoPrice, p => float.Parse(p.Commerce.Price()))
                .RuleFor(p => p.BruttoPrice, p => float.Parse(p.Commerce.Price()))
                .RuleFor(p => p.CreateDate, p => p.Date.Recent(365))
                .RuleFor(p => p.IsActive, p => p.Random.Bool())
                .RuleFor(p => p.UpdateDate, p => p.Date.Recent(365))
                .RuleFor(p => p.Description, p => p.Lorem.Text().ClampLength(1, 300));

            // zapis do pliku:
            if (saveToFile)
            {
                List<Product> myProduct = productData.Generate(numberOfPositions);

                string fileName = "product_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myProduct);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return productData;
        }

        static Faker<ProductColor> GenerateProductColor(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var productColorData = new Faker<ProductColor>("pl")
                .RuleFor(pc => pc.HexValue, pc => pc.Internet.Color().Remove(0, 1));

            // zapis do pliku:
            if (saveToFile)
            {
                List<ProductColor> myProductColor = productColorData.Generate(numberOfPositions);

                string fileName = "8_productColor_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myProductColor);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return productColorData;
        }

        static Faker<ProductDimensions> GenerateProductDimensions(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var productDimensionsData = new Faker<ProductDimensions>("pl")
                .RuleFor(pd => pd.Width, pd => pd.Random.Float(1F, float.MaxValue))
                .RuleFor(pd => pd.Height, pd => pd.Random.Float(1F, float.MaxValue))
                .RuleFor(pd => pd.Weight, pd => pd.Random.Float(1F, float.MaxValue));

            // zapis do pliku:
            if (saveToFile)
            {
                List<ProductDimensions> myProductDimensions = productDimensionsData.Generate(numberOfPositions);

                string fileName = "9_productDimensions_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myProductDimensions);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return productDimensionsData;
        }

        static Faker<ProductsCarriers> GenerateProductsCarriers(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var productsCarriersData = new Faker<ProductsCarriers>("pl")
                .RuleFor(pc => pc.ProductId, pc => pc.Random.Int(1, numberOfPositions))
                .RuleFor(pc => pc.CarrierId, pc => pc.Random.Int(1, numberOfPositions));

            // zapis do pliku:
            if (saveToFile)
            {
                List<ProductsCarriers> myProductsCarriers = productsCarriersData.Generate(numberOfPositions);

                string fileName = "productsCarriers_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myProductsCarriers);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return productsCarriersData;
        }

        static Faker<ProductsPayments> GenerateProductsPayments(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var productsPaymentsData = new Faker<ProductsPayments>("pl")
                .RuleFor(pp => pp.ProductId, pp => pp.Random.Int(1, numberOfPositions))
                .RuleFor(pp => pp.PaymentTypeId, pp => pp.Random.Int(1, numberOfPositions));

            // zapis do pliku:
            if (saveToFile)
            {
                List<ProductsPayments> myProductsPayments = productsPaymentsData.Generate(numberOfPositions);

                string fileName = "productsPayments_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myProductsPayments);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return productsPaymentsData;
        }

        static Faker<ProductsTags> GenerateProductsTags(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var productsTagsData = new Faker<ProductsTags>("pl")
                .RuleFor(pt => pt.TagId, pt => pt.Random.Int(1, numberOfPositions))
                .RuleFor(pt => pt.ProductId, pt => pt.Random.Int(1, numberOfPositions));

            // zapis do pliku:
            if (saveToFile)
            {
                List<ProductsTags> myProductsTags = productsTagsData.Generate(numberOfPositions);

                string fileName = "productsTags_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myProductsTags);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return productsTagsData;
        }

        static Faker<ProductsVariantsPhotos> GenerateProductsVariantsPhotos(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var productsVariantsPhotosData = new Faker<ProductsVariantsPhotos>("pl")
                .RuleFor(pvp => pvp.ProductVariantId, pvp => pvp.Random.Int(1, numberOfPositions))
                .RuleFor(pvp => pvp.PhotoId, pvp => pvp.Random.Int(1, numberOfPositions));

            // zapis do pliku:
            if (saveToFile)
            {
                List<ProductsVariantsPhotos> myProductsVariantsPhotos = productsVariantsPhotosData.Generate(numberOfPositions);

                string fileName = "productsVariantsPhotos_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myProductsVariantsPhotos);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return productsVariantsPhotosData;
        }

        static Faker<ProductVariant> GenerateProductVariant(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var productVariantData = new Faker<ProductVariant>("pl")
                .RuleFor(pv => pv.ColorId, pv => pv.Random.Int(1, numberOfPositions))
                .RuleFor(pv => pv.DimensionId, pv => pv.Random.Int(1, numberOfPositions))
                .RuleFor(pv => pv.Price, pv => float.Parse(pv.Commerce.Price()))
                .RuleFor(pv => pv.IsOnSale, pv => pv.Random.Bool())
                .RuleFor(pv => pv.SalePercentage, pv => pv.Random.Int(1, 100))
                .RuleFor(pv => pv.Quantity, pv => pv.Random.Int(1, int.MaxValue));

            // zapis do pliku:
            if (saveToFile)
            {
                List<ProductVariant> myProductsVariant = productVariantData.Generate(numberOfPositions);

                string fileName = "productVariant_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myProductsVariant);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return productVariantData;
        }

        static Faker<Rating> GenerateRating(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var ratingData = new Faker<Rating>("pl")
                .RuleFor(r => r.CustomerId, r => r.Random.Int(1, numberOfPositions))
                .RuleFor(r => r.ProductId, r => r.Random.Int(1, numberOfPositions))
                .RuleFor(r => r.Rate, r => r.Random.Int(1, 6));

            // zapis do pliku:
            if (saveToFile)
            {
                List<Rating> myRating = ratingData.Generate(numberOfPositions);

                string fileName = "rating_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myRating);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return ratingData;
        }

        static Faker<Status> GenerateStatus(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var index = 1;
            // ustawienie właściwości:
            var statusData = new Faker<Status>("pl")
                .RuleFor(s => s.Name, s => s.Random.Word().ClampLength(1, 25) + index++);

            // zapis do pliku:
            if (saveToFile)
            {
                List<Status> myStatus = statusData.Generate(numberOfPositions);

                string fileName = "4_status_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myStatus);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return statusData;
        }

        static Faker<Tag> GenerateTag(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var index = 1;
            // ustawienie właściwości:
            var tagData = new Faker<Tag>("pl")
                .RuleFor(t => t.Name, t => t.Random.Word().ClampLength(1, 25) + index++);

            // zapis do pliku:
            if (saveToFile)
            {
                List<Tag> myTag = tagData.Generate(numberOfPositions);

                string fileName = "5_tag_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myTag);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return tagData;
        }

        static Faker<Tax> GenerateTax(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            int[] taxes = new[] { 5, 8, 23 };
            // ustawienie właściwości:
            var taxData = new Faker<Tax>("pl")
                .RuleFor(t => t.Name, t => t.Random.Word().ClampLength(1, 15))
                .RuleFor(t => t.Interest, t => t.PickRandom(taxes));

            // zapis do pliku:
            if (saveToFile)
            {
                List<Tax> myTax = taxData.Generate(numberOfPositions);

                string fileName = "6_tax_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myTax);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return taxData;
        }

        static Faker<HomeList> GenerateHomeList(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var homeListData = new Faker<HomeList>("pl")
                .RuleFor(hl => hl.Title, hl => hl.Random.Word().ClampLength(1, 20))
                .RuleFor(hl => hl.Url, hl => hl.Internet.Url().ClampLength(1, 50))
                .RuleFor(hl => hl.IsVisible, hl => hl.Random.Bool());

            // zapis do pliku:
            if (saveToFile)
            {
                List<HomeList> myHomeList = homeListData.Generate(numberOfPositions);

                string fileName = "13_homeList_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myHomeList);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return homeListData;
        }

        static Faker<HomeProductsLists> GenerateHomeProductsList(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var homeProductsListData = new Faker<HomeProductsLists>("pl")
                .RuleFor(hpl => hpl.ListId, hpl => hpl.Random.Int(1, numberOfPositions))
                .RuleFor(hpl => hpl.ProductId, hpl => hpl.Random.Int(1, numberOfPositions));

            // zapis do pliku:
            if (saveToFile)
            {
                List<HomeProductsLists> myHomeProductsListsList = homeProductsListData.Generate(numberOfPositions);

                string fileName = "homeProductsList_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myHomeProductsListsList);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return homeProductsListData;
        }

        static Faker<ApiAccessKey> GenerateApiAccessKey(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var index = 1;
            // ustawienie właściwości:
            var apiAccessKeyData = new Faker<ApiAccessKey>("pl")
                .RuleFor(aak => aak.CreateDate, aak => aak.Date.Recent(365))
                .RuleFor(aak => aak.Key, aak => aak.Internet.Password(45) + index++);

            // zapis do pliku:
            if (saveToFile)
            {
                List<ApiAccessKey> myApiAccessKey = apiAccessKeyData.Generate(numberOfPositions);

                string fileName = "apiAccessKey_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myApiAccessKey);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return apiAccessKeyData;
        }

        static Faker<ApiKeysTablesMethods> GenerateApiKeysTablesMethods(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var apiKeysTablesMethodsData = new Faker<ApiKeysTablesMethods>("pl")
                .RuleFor(aktm => aktm.ApiAccessKeyId, aktm => aktm.Random.Int(1, numberOfPositions))
                .RuleFor(aktm => aktm.Table, aktm => aktm.PickRandom<TableType>())
                .RuleFor(aktm => aktm.HttpMethod, aktm => aktm.PickRandom<HttpMethodType>());

            // zapis do pliku:
            if (saveToFile)
            {
                List<ApiKeysTablesMethods> myApiKeysTablesMethods = apiKeysTablesMethodsData.Generate(numberOfPositions);

                string fileName = "apiKeysTablesMethods_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myApiKeysTablesMethods);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return apiKeysTablesMethodsData;
        }

        static Faker<Token> GenerateToken(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var tokenData = new Faker<Token>("pl")
                .RuleFor(t => t.Value, t => t.Random.Word())
                .RuleFor(t => t.ExpirationDate, t => t.Date.Soon(5))
                .RuleFor(t => t.UserId, t => t.Random.Int(1, numberOfPositions));

            // zapis do pliku:
            if (saveToFile)
            {
                List<Token> myToken = tokenData.Generate(numberOfPositions);

                string fileName = "token_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myToken);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return tokenData;
        }
    }
}
