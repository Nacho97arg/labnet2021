using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP2.Logic.Tests
{
    [TestClass()]
    public class DivideByZeroTests
    {
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            int divisor = 5;

            LogicClass logic = new LogicClass();

            logic.DivideByZero(divisor);
        }    
    }
}