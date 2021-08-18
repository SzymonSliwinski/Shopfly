using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models.ApiModels
{
    public enum TableType
    {
        employees,
        employeesProfiles,
        profiles,
        profilesPrivileges,
        privileges,
        customers,
        statuses,
        orders,
        ordersProducts,
        customrFavouritesProducts,
        ratings,
        comments,
        tags,
        productTags,
        products,
        productsPayments,
        paymentTypes,
        carriers,
        productsCarriers,
        taxes,
        categories,
        productsVariants,
        productsVariantsPhotos,
        photos,
        productColors,
        productDiemensions
    }

    public class Table
    {
        public int Id { get; set; }
        public TableType TableType { get; set; }
    }
}
