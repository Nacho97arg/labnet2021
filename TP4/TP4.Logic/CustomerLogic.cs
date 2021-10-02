using System;
using System.Collections.Generic;
using System.Linq;
using TP4.Common.CustomExceptions;
using TP4.Entities;

namespace TP4.Logic
{
    public class CustomerLogic : Logic, ILogic<Customers>
    {
        public List<Customers> GetAll()
        {
            try
            {
                return context.Customers.ToList();
            }
            catch(System.Data.SqlClient.SqlException e)
            {
                throw new ConnectionException(e.Message);
            }
        }
        public Customers GetOne(int id)
        {
            try
            {
                return context.Customers.Find(id);
            }
            catch(Exception e)
            {
                throw new Exception($"There was an error while trying to get the customer\n\n{e.Message}");
            }
        }
        public void AddOne(Customers newCustomer)
        {
            try
            {
                context.Customers.Add(newCustomer);
                context.SaveChanges();                
            }
            catch (Exception e)
            {
                throw new Exception($"There was an error while trying to save the customer\n\n{e.Message}");
            }
        }
        public void DeleteOne(Customers selectedCustomer)
        {
            try
            {
                context.Customers.Remove(selectedCustomer);
                context.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw new DatabaseIntegrityException($"It is not possible to the delete the solicited customer\n{e.InnerException.InnerException.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"There was an error while trying to delete the customer\n\n{e.Message}");
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

