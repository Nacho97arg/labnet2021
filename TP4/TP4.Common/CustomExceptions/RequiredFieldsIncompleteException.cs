using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Common.CustomExceptions
{
    public class RequiredFieldsIncompleteException : Exception
    { 
        public RequiredFieldsIncompleteException() : base("Verify that the required fields have been completed")
        {
        }
    }
}
