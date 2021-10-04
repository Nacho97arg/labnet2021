using Lab.Api.Models;
using System.Collections.Generic;
using System.Linq;
using TP4.Entities;

namespace Lab.Api.Controllers.Helpers
{
    public static class Mappers
    {
        public static List<SuppliersResponse> MapListMapMultipleSuppliersToResponses(List<Suppliers> sourceSuppliers)
        {
            List<SuppliersResponse> suppliersResponses = sourceSuppliers.Select(s => new SuppliersResponse
            {
                SupplierID = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ContactTitle = s.ContactTitle,
                Address = s.Address,
                City = s.City,
                Region = s.Region,
                PostalCode = s.PostalCode,
                Country = s.Country,
                Phone = s.Phone,
                Fax = s.Fax,
                HomePage = s.HomePage
            }).ToList();
            return suppliersResponses;
        }
        public static List<CustomersResponse> MapListMapMultipleCustomersToResponses(List<Customers> sourceCustomers)
        {
            List<CustomersResponse> customersResponses = sourceCustomers.Select(c => new CustomersResponse
            {
                CustomerID = c.CustomerID,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                ContactTitle = c.ContactTitle,
                Address = c.Address,
                City = c.City,
                Region = c.Region,
                PostalCode = c.PostalCode,
                Country = c.Country,
                Phone = c.Phone,
                Fax = c.Fax
            }).ToList();
            return customersResponses;
        }
        public static SuppliersResponse MapSupplierToResponse(Suppliers sourceSupplier)
        {
            SuppliersResponse supplierResponse = new SuppliersResponse()
            {
                SupplierID = sourceSupplier.SupplierID,
                CompanyName = sourceSupplier.CompanyName,
                ContactName = sourceSupplier.ContactName,
                ContactTitle = sourceSupplier.ContactTitle,
                Address = sourceSupplier.Address,
                City = sourceSupplier.City,
                Region = sourceSupplier.Region,
                PostalCode = sourceSupplier.PostalCode,
                Country = sourceSupplier.Country,
                Phone = sourceSupplier.Phone,
                Fax = sourceSupplier.Fax,
                HomePage = sourceSupplier.HomePage
            };
            return supplierResponse;
        }
        public static CustomersResponse MapCustomerToResponse(Customers sourceCustomer)
        {
            CustomersResponse customerResponse = new CustomersResponse()
            {
                CustomerID = sourceCustomer.CustomerID,
                CompanyName = sourceCustomer.CompanyName,
                ContactName = sourceCustomer.ContactName,
                ContactTitle = sourceCustomer.ContactTitle,
                Address = sourceCustomer.Address,
                City = sourceCustomer.City,
                Region = sourceCustomer.Region,
                PostalCode = sourceCustomer.PostalCode,
                Country = sourceCustomer.Country,
                Phone = sourceCustomer.Phone,
                Fax = sourceCustomer.Fax
            };
            return customerResponse;
        }
        internal static void MapRequestToSupplier(SuppliersRequest suppliersRequest, ref Suppliers supplier)
        {
            supplier.CompanyName = suppliersRequest.CompanyName;
            supplier.ContactName = suppliersRequest.ContactName;
            supplier.ContactTitle = suppliersRequest.ContactTitle;
            supplier.Address = suppliersRequest.Address;
            supplier.City = suppliersRequest.City;
            supplier.Region = suppliersRequest.Region;
            supplier.PostalCode = suppliersRequest.PostalCode;
            supplier.Country = suppliersRequest.Country;
            supplier.Phone = suppliersRequest.Phone;
            supplier.Fax = suppliersRequest.Fax;
            supplier.HomePage = suppliersRequest.HomePage;
        }
        internal static void MapRequestToNewCustomer(CustomersRequest customersRequest, ref Customers customer)
        {
            customer.CustomerID = customersRequest.CustomerID;
            customer.CompanyName = customersRequest.CompanyName;
            customer.ContactName = customersRequest.ContactName;
            customer.ContactTitle = customersRequest.ContactTitle;
            customer.Address = customersRequest.Address;
            customer.City = customersRequest.City;
            customer.Region = customersRequest.Region;
            customer.PostalCode = customersRequest.PostalCode;
            customer.Country = customersRequest.Country;
            customer.Phone = customersRequest.Phone;
            customer.Fax = customersRequest.Fax;
        }
        internal static void MapRequestToCustomer(CustomersRequest customersRequest, ref Customers customer)
        {
            customer.CompanyName = customersRequest.CompanyName;
            customer.ContactName = customersRequest.ContactName;
            customer.ContactTitle = customersRequest.ContactTitle;
            customer.Address = customersRequest.Address;
            customer.City = customersRequest.City;
            customer.Region = customersRequest.Region;
            customer.PostalCode = customersRequest.PostalCode;
            customer.Country = customersRequest.Country;
            customer.Phone = customersRequest.Phone;
            customer.Fax = customersRequest.Fax;
        }
    }
}