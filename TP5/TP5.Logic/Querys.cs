using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP5.Entities;
using TP5.Data;
using TP5.Entities.JoinEntities;

namespace TP5.Logic
{
    public class Querys
    {
        private readonly NorthwindContext context;
        public Querys(NorthwindContext context)
        {
            this.context = context;
        }
        /*1*/
        public Customers GetACustomer()
        {
            var aCustomer = context.Customers.First();
            return aCustomer;
        }
        /*2*/
        public IQueryable<Products> GetOutOfStockProducts()
        {
            var outOfStockProducts = context.Products.Where(p => p.UnitsInStock == 0);
            return outOfStockProducts;
        }
        /*3*/
        public IQueryable<Products> GetOnStockProductsStartingAt(decimal price)
        {
            var onStockProducts = from product in context.Products
                                  where (product.UnitsInStock > 0) && (product.UnitPrice > price)
                                  select product;
            return onStockProducts;
        }
        /*4*/
        public IQueryable<Customers> GetCostumersOnRegion(string region)
        {
            var customerOnRegion = from customer in context.Customers
                                   where customer.Region == region
                                   select customer;
            return customerOnRegion;
        }
        /*5*/
        public Products GetProduct(int productID)
        {
           var product = context.Products.FirstOrDefault(p => p.ProductID == productID);
            return product;
        }
        /*6*/
        public IQueryable<CustomerNamesUpperLower> GetCustomersNames()
        {
            var customersNames = context.Customers.Select(c => new CustomerNamesUpperLower
            {
                CompanyNameLower = c.CompanyName.ToLower(),
                ContactNameLower = c.ContactName.ToLower(),
                CompanyNameUpper = c.CompanyName.ToUpper(),
                ContactNameUpper = c.ContactName.ToUpper()
            });
            return customersNames;
        }
        /*7*/
        public IQueryable GetOrdersByCustomersRegionAndDate(string region, DateTime date)
        {
            var ordersCustomers = from customer in context.Customers
                                  join order in context.Orders
                                  on customer.CustomerID equals order.CustomerID
                                  where (customer.Region == region) && (order.OrderDate >= date)
                                  select new CustomerAndRegionJoin
                                  {
                                      CustomerID = customer.CustomerID,
                                      ContactName = customer.ContactName,
                                      Address = customer.Address,
                                      City = customer.City,
                                      Region = customer.Region,
                                      ShipName = order.ShipName,
                                      ShipAddress = order.ShipAddress,
                                      ShipCity = order.ShipCity,
                                      OrderDate = order.OrderDate,
                                      ShippedDate = order.ShippedDate
                                  };
            return ordersCustomers;
        }
        /*8*/
        public IQueryable<Customers> GetFirstNCustomers(int numberOfCustomers)
        {
            var firstThreeCustomers = context.Customers.Take(numberOfCustomers);
            return firstThreeCustomers;
        }
        /*9*/
        public IQueryable<Products> GetProductsAlfOrdered()
        {
            var productsOrdered = context.Products.OrderBy(p => p.ProductName);
            return productsOrdered;
        }
        /*10*/
        public IQueryable<Products> GetProductsOrderedByStock()
        {
            var productsOrdered = context.Products.OrderByDescending(p => p.UnitsInStock);
            return productsOrdered;
        }
        /*11*/
        public IEnumerable<Categories> GetAssociatedCategories()
        {
            var associatedCategories = (from product in context.Products
                                        join category in context.Categories
                                        on product.CategoryID equals category.CategoryID
                                        select category).ToList().Distinct();
            return associatedCategories;
        }
        /*12*/
        public Products GetFirstElement(List<Products> products)
        {
            var firstElement = (from product in products
                                select product).FirstOrDefault();
            return firstElement;
        }
        /*13*/
        public IQueryable<CustomerOrdersQuantityJoin> GetOrdersQuantityByCustumer()
        {
            var ordersQuantityByCustomer = from customer in context.Customers
                                           join order in context.Orders
                                           on customer.CustomerID equals order.CustomerID
                                           group customer by customer into groupedCustomers
                                           select new CustomerOrdersQuantityJoin{ Customer = groupedCustomers.Key, OrdersQuantity = groupedCustomers.Count() };
            return ordersQuantityByCustomer;
        }
    }
}
