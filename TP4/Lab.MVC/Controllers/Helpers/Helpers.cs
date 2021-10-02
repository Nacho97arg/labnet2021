using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab.MVC.Models;
using TP4.Entities;

namespace Lab.MVC.Controllers.Helpers
{
    public static class Helpers
    {
        public static SupplierView MapEntityToModel(Suppliers supplier)
        {
            SupplierView supplierView = new SupplierView 
            {   SupplierID = supplier.SupplierID, 
                CompanyName = supplier.CompanyName,
                Address = supplier.Address,
                City = supplier.City
            };
            return supplierView;
        
        }
        public static void MapViewToSupplier(SupplierView supplierView, Suppliers supplier)
        {
            supplier.CompanyName = supplierView.CompanyName;
            supplier.Address = supplierView.Address;
            supplier.City = supplierView.City;
        }
    }
}