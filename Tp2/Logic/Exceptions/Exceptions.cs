using System;

namespace TP2.Logic.Exceptions
{
    public class MyException : Exception
    {
        public MyException(string message) : base(message)
        {
        }
    }
}
