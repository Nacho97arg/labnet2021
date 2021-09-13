using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP2.Logic.Tests
{
    [TestClass()]
    public class DivideByTests
    {
        [TestMethod()]
        public void ValidInputs()
        {
            int dividend = 10;
            int divisor = 2;
            int expectedResult = 5;
            LogicClass logic = new LogicClass();

            int result = logic.DivideBy(dividend, divisor);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void InvalidDividendInput()
        {
            int dividend = int.Parse("h");
            int divisor = 2;
            LogicClass logic = new LogicClass();

            logic.DivideBy(dividend, divisor);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void InvalidDivisorInput()
        {
            int dividend = 10;
            int divisor = int.Parse("h");
            LogicClass logic = new LogicClass();

            logic.DivideBy(dividend, divisor);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyDividendInput()
        {
            int dividend = int.Parse(null);
            int divisor = 2;
            LogicClass logic = new LogicClass();

            logic.DivideBy(dividend, divisor);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyDivisorInput()
        {
            int dividend = 10;
            int divisor = int.Parse(null);
            LogicClass logic = new LogicClass();

            logic.DivideBy(dividend, divisor);
        }
    }
}
