using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab.MVC.Models;
using TP4.Entities;

namespace Lab.MVC.Controllers.Helpers
{
    public static class Mappers
    {
        public static SupplierView MapSupplierToView(Suppliers supplier)
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

        public static List<SupplierView> MapMultipleSuppliersToViews(List<Suppliers> suppliers)
        {
            List<SupplierView> suppliersViews = suppliers.Select(s => new SupplierView
                                                {
                                                    SupplierID = s.SupplierID,
                                                    CompanyName = s.CompanyName,
                                                    Address = s.Address,
                                                    City = s.City
                                                }).ToList();
            return suppliersViews;
        }
    }
}