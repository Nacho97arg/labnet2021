using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Common.CustomExceptions
{
    public class ConnectionException : Exception
    {
        public ConnectionException(string message) : base($"There was a problem connecting to the database\n{message}")
        {
        }
    }
}
