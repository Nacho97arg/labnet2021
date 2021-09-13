using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Logic
{
    public interface ILogicClass
    {
        int DivideByZero(int dividend);
        int DivideBy(int dividend, int divisor);
        void GenerateException();
        void GenerateCustomException();

    }
}
