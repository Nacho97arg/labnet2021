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
            //NorthwindContext context = new NorthwindContext();
            LINQuerys logic = new LINQuerys(context);
            Customers expectedCustomer = context.Customers.First();

            Customers customer = logic.GetACustomer();

            Assert.AreEqual(expectedCustomer, customer);
        }
        [TestMethod]
        public void TestGetOutOfStockProducts()
        {
            //NorthwindContext context = new NorthwindContext();
            LINQuerys logic = new LINQuerys(context);
            List<Products> expectedProductsOutofStock = context.Products.Where(p => p.UnitsInStock == 0).ToList();

            List<Products> productsOutOfStock = logic.GetOutOfStockProducts().ToList();

            CollectionAssert.AreEqual(expectedProductsOutofStock, productsOutOfStock);
        }
        [TestMethod]
        public void TestGetOnStockProductsStartingAt()
        {
            //NorthwindContext context = new NorthwindContext();
            LINQuerys logic = new LINQuerys(context);
            const decimal MINIMUM_FILTER_PRICE = 3;
            List<Products> expectedProductsOnStock = context.Products.Where(p => (p.UnitsInStock > 0) && (p.UnitPrice > MINIMUM_FILTER_PRICE)).ToList();

            List<Products> productsOnStock = logic.GetOnStockProductsStartingAt(MINIMUM_FILTER_PRICE).ToList();

            CollectionAssert.AreEqual(expectedProductsOnStock, productsOnStock);
        }
        [TestMethod]
        public void TestGetCustomersOnRegion()
        {
            //NorthwindContext context = new NorthwindContext();
            LINQuerys logic = new LINQuerys(context);
            const string REGION_TO_FILTER = "WA";
            List<Customers> expectedCostomersOnRegion = context.Customers.Where(c => c.Region==REGION_TO_FILTER).ToList();

            List<Customers> customersOnRegion = logic.GetCostumersOnRegion(REGION_TO_FILTER).ToList();

            CollectionAssert.AreEqual(expectedCostomersOnRegion, customersOnRegion);
        }
        [TestMethod]
        public void TestGetProduct()
        {
            //NorthwindContext context = new NorthwindContext();
            LINQuerys logic = new LINQuerys(context);
            const int PRODUCTID_TO_GET = 76;
            Products expectedProduct = context.Products.FirstOrDefault(p => p.ProductID == PRODUCTID_TO_GET);

            Products product = logic.GetProduct(PRODUCTID_TO_GET);

            Assert.AreEqual(expectedProduct, product);
        }
        [TestMethod]
        public void TestGetCustomersNames()
        {
            //NorthwindContext context = new NorthwindContext();
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
