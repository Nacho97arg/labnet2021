using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP2.Logic.Tests
{
    [TestClass]
    public class GenerateExceptionTests
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void GenerateExceptionTest()
        {
            new LogicClass().GenerateException();
        }
    }
}
