using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.Entities;

namespace TP4.Logic
{
    public class CustomerLogic : Logic, ILogic<Customers>
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }
        public void AddOne(Customers newCustomer)
        {
            context.Customers.Add(newCustomer);
            context.SaveChanges();
        }
        public void DeleteOne(Customers selectedCustomer)
        {
            context.Customers.Remove(selectedCustomer);
            context.SaveChanges();
        }
        public void Update()
        {
            context.SaveChanges();
        }
    }
}

