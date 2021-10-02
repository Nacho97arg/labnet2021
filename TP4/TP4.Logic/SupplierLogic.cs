using System;
using System.Collections.Generic;
using System.Linq;
using TP4.Common.CustomExceptions;
using TP4.Entities;

namespace TP4.Logic
{
    public class SupplierLogic : Logic, ILogic<Suppliers>
    {
        public List<Suppliers> GetAll()
        {
            try
            {
                return context.Suppliers.ToList();
            }
            catch(System.Data.SqlClient.SqlException e)
            {
                throw new ConnectionException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception($"There was an error while trying to show the suppliers\n\n{e.Message}");
            }

        }
        public Suppliers GetOne(int id)
        {
            try
            {
                return context.Suppliers.Find(id);
            }
            catch(Exception e)
            {
                throw new Exception($"There was an error while trying to get the supplier\n\n{e.Message}");
            }
        }
        public void AddOne(Suppliers newSupplier)
        {
            try
            {
                context.Suppliers.Add(newSupplier);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"There was an error while trying to save the supplier\n\n{e.Message}");
            }
        }
        public void DeleteOne(Suppliers selectedSupplier)
        {
            try
            {
                context.Suppliers.Remove(selectedSupplier);
                context.SaveChanges();
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw new DatabaseIntegrityException($"It is not possible to the delete the solicited supplier\n{e.InnerException.InnerException.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"There was an error while trying to delete the supplier\n\n{e.Message}");
            }
        }
        public void Update()
        {
            try
            {
                context.SaveChanges();            
            }
            catch (Exception e)
            {
                throw new Exception($"There was an error while trying to save the changes\n\n{e.Message}");
            }
        }
    }
}
