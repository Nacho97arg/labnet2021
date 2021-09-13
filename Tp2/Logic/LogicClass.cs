using System;
using TP2.Logic.Exceptions;
using TP2.Logic.ExtensionMethods;

namespace TP2.Logic
{
    /// <summary>
    /// Representa la logica de la aplicacion.
    /// </summary>
    public class LogicClass : ILogicClass
    {
        public int DivideByZero(int dividend)
        {
            return dividend.DivideByZero();
        }
        public int DivideBy(int dividend, int divisor)
        {
            return dividend.DivideBy(divisor);            
        }
        public void GenerateException()
        {
            throw new Exception();
        }
        public void GenerateCustomException()
        {
            throw new MyException("Excepcion personalizada");
        }
    }
}
