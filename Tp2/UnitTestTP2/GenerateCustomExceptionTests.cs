using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2.Logic.Exceptions;

namespace TP2.Logic.Tests
{
    [TestClass]
    public class GenerateCustomExceptionTests
    {
        [TestMethod()]
        [ExpectedException(typeof(MyException))]
        public void GenerateCustomExceptionTest()
        {
            new LogicClass().GenerateCustomException();
        }
    }
}
