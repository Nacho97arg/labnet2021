using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.Entities;
using TP4.Data;

namespace TP4.Logic
{
    public class SupplierLogic : Logic, ILogic<Suppliers>
    {
        public void AddOne(Suppliers newSupplier)
        {
                context.Suppliers.Add(newSupplier);
                context.SaveChanges();
        }

        public void DeleteOne(Suppliers selectedSupplier)
        {

            context.Suppliers.Remove(selectedSupplier);
            context.SaveChanges();
        }

        public List<Suppliers> GetAll()
        {
            return context.Suppliers.ToList();
        }

        public void Update()
        {
            context.SaveChanges();
        }
    }
}
