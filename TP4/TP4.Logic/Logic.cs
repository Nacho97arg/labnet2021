using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.Data;

namespace TP4.Logic
{
    public abstract class Logic
    {
        protected NorthwindContext context;
        public NorthwindContext SetContext 
        {
            set
            {
                this.context = value;
            }
        }


        public Logic()
        {
            context = new NorthwindContext();
        }
    }
}
