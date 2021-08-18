﻿using Common.Models.ShopModels;
using Common.Models.ShopPanelModels;
using Common.Models.ApiModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public class AppDbContext : DbContext
    {
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfilesPrivileges> ProfilesPrivileges { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeesProfiles> EmployeesProfiles { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerFavouritesProducts> CustomerFavouritesProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersProducts> OrdersProducts { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductDimensions> ProductDimensions { get; set; }
        public DbSet<ProductsCarriers> ProductsCarriers { get; set; }
        public DbSet<ProductsPayments> ProductsPayments { get; set; }
        public DbSet<ProductsTags> ProductsTags { get; set; }
        public DbSet<ProductsVariantsPhotos> ProductsVariantsPhotos { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Tax> Taxes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuration
            ConfigurePrivileges(modelBuilder);
            ConfigureProfiles(modelBuilder);
            ConfigureEmployees(modelBuilder);
            ConfigureCarriers(modelBuilder);
            ConfigureCategories(modelBuilder);
            ConfigureComments(modelBuilder);
            ConfigureCustomers(modelBuilder);
            ConfigureOrders(modelBuilder);
            ConfigurePaymentTypes(modelBuilder);
            ConfigurePhotos(modelBuilder);
            ConfigureProducts(modelBuilder);
            ConfigureProductColors(modelBuilder);
            ConfigureProductVariants(modelBuilder);
            ConfigureStatuses(modelBuilder);
            ConfigureTags(modelBuilder);
            ConfigureTaxes(modelBuilder);
            ConfigureOrdersProducts(modelBuilder);

            //relations
            SetPrivilegesProfilesRelation(modelBuilder);
            SetEmployeesProfilesRelation(modelBuilder);
            SetCommentsCustomersRelation(modelBuilder);
            SetCustomerFavouriteProductsRelation(modelBuilder);
            SetOrdersProductRelation(modelBuilder);
            SetProductsCarriersRelation(modelBuilder);
            SetProductPaymentsRelation(modelBuilder);
            SetProductTagsRelation(modelBuilder);
            SetProductVariantsPhotosRelation(modelBuilder);
            SetCustomersRatingsRelation(modelBuilder);
        }

        // ShopPanelModels configuration:
        private void ConfigurePrivileges(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Privilege>()
                .Property(p => p.Name).HasMaxLength(30);
        }

        private void ConfigureProfiles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .Property(p => p.Name).HasMaxLength(30);
        }

        private void ConfigureEmployees(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Surname).HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Email).HasMaxLength(30);
            // todo tutaj prawdopodobnie trzeba będzie zrobić właściwość do hasła
        }


        // ShopModels configuration:
        private void ConfigureCarriers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>()
                .Property(c => c.Name).HasMaxLength(30);
            modelBuilder.Entity<Carrier>()
                .Property(c => c.Logo).HasMaxLength(50);
        }

        private void ConfigureCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.Name).HasMaxLength(30);
        }

        private void ConfigureComments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(c => c.Content).HasMaxLength(200);
        }

        private void ConfigureCustomers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name).HasMaxLength(50);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Surname).HasMaxLength(50);
            modelBuilder.Entity<Customer>()
                .Property(c => c.PhoneNumber).HasMaxLength(20);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Email).HasMaxLength(30);

            // todo password
        }

        private void ConfigureOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(o => o.AdditionalDescription).HasMaxLength(200).IsRequired(false);

            // Delivery:
            modelBuilder.Entity<Order>()
                .Property(o => o.DeliveryAddressStreet).HasMaxLength(30);
            modelBuilder.Entity<Order>()
                .Property(o => o.DeliveryAddressPostal).HasMaxLength(30);
            modelBuilder.Entity<Order>()
                .Property(o => o.DeliveryAddressCity).HasMaxLength(30);
            modelBuilder.Entity<Order>()
                .Property(o => o.DeliveryAddressCountry).HasMaxLength(30);

            // Billing:
            modelBuilder.Entity<Order>()
                .Property(o => o.BillingAddressStreet).HasMaxLength(30).IsRequired(false);
            modelBuilder.Entity<Order>()
                .Property(o => o.BillingAddressPostal).HasMaxLength(30).IsRequired(false);
            modelBuilder.Entity<Order>()
                .Property(o => o.BillingAddressCity).HasMaxLength(30).IsRequired(false);
            modelBuilder.Entity<Order>()
                .Property(o => o.BillingAddressCountry).HasMaxLength(30).IsRequired(false);

            // Additional:
            modelBuilder.Entity<Order>()
                .Property(o => o.Nip).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<Order>()
                .Property(o => o.CompanyName).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerPhoneNumber).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerEmail).HasMaxLength(10).IsRequired(false);
        }

        private void ConfigurePaymentTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentType>()
                .Property(pt => pt.Name).HasMaxLength(30);
            modelBuilder.Entity<PaymentType>()
                .Property(pt => pt.Icon).HasMaxLength(50);
        }

        private void ConfigurePhotos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>()
                .Property(p => p.Path).HasMaxLength(50);
        }

        private void ConfigureProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name).HasMaxLength(30);
            modelBuilder.Entity<Product>()
                .Property(p => p.IsLowStock).IsRequired(false);
            modelBuilder.Entity<Product>()
                .Property(p => p.AdditionalShippingCost).IsRequired(false);
            modelBuilder.Entity<Product>()
                .Property(p => p.Description).HasMaxLength(300);
        }

        private void ConfigureProductColors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductColor>()
                .Property(pc => pc.HexValue).HasMaxLength(6);
        }

        private void ConfigureProductVariants(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductVariant>()
                .Property(pv => pv.ColorId).IsRequired(false);
            modelBuilder.Entity<ProductVariant>()
                .Property(pv => pv.DimensionId).IsRequired(false);
            modelBuilder.Entity<ProductVariant>()
                .Property(pv => pv.IsOnSale).IsRequired(false);
            modelBuilder.Entity<ProductVariant>()
                .Property(pv => pv.SalePercentage).IsRequired(false);
            modelBuilder.Entity<ProductVariant>()
                .Property(pv => pv.Quantity).IsRequired(false);
        }

        private void ConfigureStatuses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .Property(s => s.Name).HasMaxLength(30);
        }

        private void ConfigureTags(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .Property(t => t.Name).HasMaxLength(30);
        }

        private void ConfigureTaxes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tax>()
                .Property(t => t.Name).HasMaxLength(15);
        }

        private void ConfigureOrdersProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersProducts>()
                .Property(op => op.ProductQuantity).IsRequired(false);
        }


        // ShopPanelModels relations:
        private void SetPrivilegesProfilesRelation(ModelBuilder modelBuilder)
        {
            // relacja many to many:
            modelBuilder.Entity<ProfilesPrivileges>()
                 .HasKey(pp => new { pp.PrivilegeId, pp.ProfileId });
            modelBuilder.Entity<ProfilesPrivileges>()
                .HasOne(pp => pp.Profile)
                .WithMany(p => p.ProfilesPrivileges)
                .HasForeignKey(pp => pp.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProfilesPrivileges>()
                .HasOne(pp => pp.Privilege)
                .WithMany(p => p.ProfilesPrivileges)
                .HasForeignKey(pp => pp.PrivilegeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetEmployeesProfilesRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeesProfiles>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProfileId });
            modelBuilder.Entity<EmployeesProfiles>()
                .HasOne(ep => ep.Profile)
                .WithMany(ep => ep.EmployeesProfiles)
                .HasForeignKey(ep => ep.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmployeesProfiles>()
                .HasOne(ep => ep.Employee)
                .WithMany(ep => ep.EmployeesProfiles)
                .HasForeignKey(ep => ep.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }


        // ShopModels relations:
        private void SetCommentsCustomersRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasKey(cc => new { cc.CustomerId, cc.ProductId });
            modelBuilder.Entity<Comment>()
                .HasOne(cc => cc.Product)
                .WithMany(cc => cc.Comments)
                .HasForeignKey(cc => cc.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>()
                .HasOne(cc => cc.Customer)
                .WithMany(cc => cc.Comments)
                .HasForeignKey(cc => cc.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetCustomerFavouriteProductsRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerFavouritesProducts>()
                .HasKey(cfp => new { cfp.CustomerId, cfp.ProductId });
            modelBuilder.Entity<CustomerFavouritesProducts>()
                .HasOne(cfp => cfp.Customer)
                .WithMany(cfp => cfp.CustomerFavouritesProducts)
                .HasForeignKey(cfp => cfp.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CustomerFavouritesProducts>()
                .HasOne(cfp => cfp.Product)
                .WithMany(cfp => cfp.CustomerFavouritesProducts)
                .HasForeignKey(cfp => cfp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetOrdersProductRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersProducts>()
                .HasKey(op => new { op.OrderId, op.ProductId });
            modelBuilder.Entity<OrdersProducts>()
                .HasOne(op => op.Order)
                .WithMany(op => op.OrdersProducts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrdersProducts>()
                .HasOne(op => op.Product)
                .WithMany(op => op.OrdersProducts)
                .HasForeignKey(op => op.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetProductsCarriersRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsCarriers>()
                .HasKey(pc => new { pc.CarrierId, pc.ProductId });
            modelBuilder.Entity<ProductsCarriers>()
                .HasOne(pc => pc.Carrier)
                .WithMany(pc => pc.ProductsCarriers)
                .HasForeignKey(pc => pc.CarrierId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductsCarriers>()
                .HasOne(pc => pc.Product)
                .WithMany(pc => pc.ProductsCarriers)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetProductPaymentsRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsPayments>()
                .HasKey(pp => new { pp.ProductId, pp.PaymentTypeId });
            modelBuilder.Entity<ProductsPayments>()
                .HasOne(pp => pp.Product)
                .WithMany(pp => pp.ProductsPayments)
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductsPayments>()
                .HasOne(pp => pp.PaymentType)
                .WithMany(pp => pp.ProductsPayments)
                .HasForeignKey(pp => pp.PaymentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetProductTagsRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsTags>()
                .HasKey(pt => new { pt.TagId, pt.ProductId });
            modelBuilder.Entity<ProductsTags>()
                .HasOne(pt => pt.Tag)
                .WithMany(pt => pt.ProductsTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductsTags>()
                .HasOne(pt => pt.Product)
                .WithMany(pt => pt.ProductsTags)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetProductVariantsPhotosRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsVariantsPhotos>()
                .HasKey(pvp => new { pvp.ProductVariantId, pvp.PhotoId });
            modelBuilder.Entity<ProductsVariantsPhotos>()
                .HasOne(pvp => pvp.ProductVariant)
                .WithMany(pvp => pvp.ProductsVariantsPhotos)
                .HasForeignKey(pvp => pvp.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductsVariantsPhotos>()
                .HasOne(pvp => pvp.Photo)
                .WithMany(pvp => pvp.ProductsVariantsPhotos)
                .HasForeignKey(pvp => pvp.PhotoId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetCustomersRatingsRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasKey(r => new { r.CustomerId, r.ProductId });
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Customer)
                .WithMany(r => r.Ratings)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Product)
                .WithMany(r => r.Ratings)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
