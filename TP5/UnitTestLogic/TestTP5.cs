using TP5.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TP5.Data;
using TP5.Entities;
using TP5.Entities.JoinEntities;

namespace TP5.Logic.Test
{
    [TestClass]
    public class TestTP5
    {
        private static readonly NorthwindContext context = new NorthwindContext();
        [TestMethod]
        public void TestGetACustomer()
        {
            LINQuerys logic = new LINQuerys(context);

            Customers customer = logic.GetACustomer();

            Assert.IsInstanceOfType(customer, new Customers().GetType());
        }
        [TestMethod]
        public void TestGetOutOfStockProducts()
        {
            LINQuerys logic = new LINQuerys(context);

            List<Products> productsOutOfStock = logic.GetOutOfStockProducts().ToList();

            foreach (Products product in productsOutOfStock)
            {
                if (product.UnitsInStock != 0)
                    throw new AssertFailedException();
            }
        }
        [TestMethod]
        public void TestGetOnStockProductsStartingAt()
        {
            LINQuerys logic = new LINQuerys(context);
            const decimal MINIMUM_FILTER_PRICE = 3;

            List<Products> productsOnStock = logic.GetOnStockProductsStartingAt(MINIMUM_FILTER_PRICE).ToList();

            foreach (Products product in productsOnStock)
            {
                if ((product.UnitsInStock == 0) || (product.UnitPrice < MINIMUM_FILTER_PRICE))
                    throw new AssertFailedException();
            }
        }
        [TestMethod]
        public void TestGetCustomersOnRegion()
        {
            LINQuerys logic = new LINQuerys(context);
            const string REGION_TO_FILTER = "WA";

            List<Customers> customersOnRegion = logic.GetCostumersOnRegion(REGION_TO_FILTER).ToList();

            foreach(Customers customer in customersOnRegion)
            {
                if (customer.Region != REGION_TO_FILTER)
                    throw new AssertFailedException();
            }        }
        [TestMethod]
        public void TestGetProduct()
        {
            LINQuerys logic = new LINQuerys(context);
            const int PRODUCTID_TO_GET = 76;

            Products product = logic.GetProduct(PRODUCTID_TO_GET);

            if (product.ProductID != PRODUCTID_TO_GET)
                throw new AssertFailedException();            
        }
        [TestMethod]
        public void TestGetCustomersNames()
        {
            LINQuerys logic = new LINQuerys(context);
            bool flag = true;
            List<Customers> customers =(from customer in context.Customers
                                                    select customer).ToList();

            List<CustomerNamesUpperLower> customersNames = logic.GetCustomersNames().ToList();

            for (int index=0; index<customersNames.Count; index++ )
            {
                
                if ((customersNames[index].CompanyNameLower != customers[index].CompanyName.ToLower()) || 
                    (customersNames[index].CompanyNameUpper != customers[index].CompanyName.ToUpper()) || 
                    (customersNames[index].ContactNameLower != customers[index].ContactName.ToLower()) || 
                    (customersNames[index].ContactNameUpper != customers[index].ContactName.ToUpper()))
                {
                    flag = false;
                    break;
                }  
            }
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void TestGetOrdersByCustomersRegionAndDate()
        {
            LINQuerys logic = new LINQuerys(context);
            const string REGION = "WA";
            DateTime DATE_TIME = DateTime.Parse("01/01/1997");
            bool flag = true;

            IQueryable ordersAndCustomers = logic.GetOrdersByCustomersRegionAndDate(REGION, DATE_TIME);

            foreach (CustomerAndRegionJoin orderCustomer in ordersAndCustomers)
            {
                if ((orderCustomer.Region != REGION) || (orderCustomer.OrderDate < DATE_TIME))
                {
                    flag = false;
                    break;
                }
            }
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void TestGetFirstNCustomers()
        {
            LINQuerys logic = new LINQuerys(context);
            const int N_CUSTOMERS = 3;

            List<Customers> firstNCustomers = logic.GetFirstNCustomers(N_CUSTOMERS).ToList();

            Assert.IsTrue(firstNCustomers.Count == N_CUSTOMERS);
        }
        [TestMethod]
        public void TestGetProductsOrderedByStock()
        {
            LINQuerys logic = new LINQuerys(context);
            List<Products> expectedProductsOrdered =    (from product in context.Products
                                                        orderby product.UnitsInStock descending
                                                        select product).ToList();

            List <Products> productsOrdered = logic.GetProductsOrderedByStock().ToList();

            CollectionAssert.AreEqual(expectedProductsOrdered, productsOrdered);
        }
        [TestMethod]
        public void TestGetProductsAlfOrdered()
        {
            LINQuerys logic = new LINQuerys(context);
            List<Products> expectedProductsOrdered = (from product in context.Products
                                                      orderby product.ProductName
                                                      select product).ToList();

            List<Products> productsOrdered = logic.GetProductsAlfOrdered().ToList();

            CollectionAssert.AreEqual(expectedProductsOrdered, productsOrdered);
        }
        [TestMethod]
        public void TestAssociatedCategories()
        {
            LINQuerys logic = new LINQuerys(context);

            List<Categories> associatedCategories = logic.GetAssociatedCategories().ToList();

            CollectionAssert.AllItemsAreUnique(associatedCategories);
        }
        [TestMethod]
        public void TestGetFirstElement()
        {
            LINQuerys logic = new LINQuerys(context);
            List<Products> listOfProducts = context.Products.Take(5).ToList();
            Products expectedFirstProduct = listOfProducts.FirstOrDefault();

            Products firstProduct = logic.GetFirstElement(listOfProducts);

            Assert.AreEqual(expectedFirstProduct, firstProduct);
        }
        [TestMethod]
        public void TestGetOrdersQuantityByCostumer()
        {
            LINQuerys logic = new LINQuerys(context);

            List<CustomerOrdersQuantity> ordersQuantity = logic.GetOrdersQuantityByCustumer().ToList();

            CollectionAssert.AllItemsAreUnique(ordersQuantity);
        }
    }
}
