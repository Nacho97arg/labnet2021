using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Common.CustomExceptions
{
    public class DatabaseIntegrityException : Exception
    {
        public DatabaseIntegrityException(string message) : base(message)
        {
        }
    }
}
