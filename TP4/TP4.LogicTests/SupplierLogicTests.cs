using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP4.Logic;
using TP4.Entities;
using TP4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Logic.Tests
{
    [TestClass()]
    public class SupplierLogicTests
    {
        [TestMethod()]
        public void GetAll_ProperFunctioning_ReturnsAllSuppliersInTheDB()
        {
            NorthwindContext context = new NorthwindContext();
            SupplierLogic supplierLogic = new SupplierLogic{ SetContext = context };
            List<Suppliers> expectedSuppliers = context.Suppliers.ToList();

            List<Suppliers> suppliers = supplierLogic.GetAll();

            CollectionAssert.AreEqual(expectedSuppliers, suppliers);
        }
    }
}