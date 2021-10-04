using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TP4.Entities;
using TP4.Logic;
using Lab.Api.Models;
using Lab.Api.Controllers.Helpers;

namespace Lab.Api.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ILogic<Customers,string> customerLogic = new CustomerLogic();
        //GET: /api/customers
        public IHttpActionResult Get()
        {
            try
            {
                List<Customers> customers = customerLogic.GetAll();
                List<CustomersResponse> customersResponses = Mappers.MapListMapMultipleCustomersToResponses(customers);
                return Ok(customersResponses);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        //GET: /api/customers/{Id}
        public IHttpActionResult Get(string id)
        {
            try
            {
                Customers customer = customerLogic.GetOne(id);
                if (customer == null) return NotFound();

                CustomersResponse customerResponse = Mappers.MapCustomerToResponse(customer);
                return Ok(customerResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        //DELETE: /api/customers/{Id}
        public IHttpActionResult Delete(string id)
        {
            try
            {
                Customers customerToDelete = customerLogic.GetOne(id);
                if (customerToDelete == null) return NotFound();

                customerLogic.DeleteOne(customerToDelete);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        //PUT: /api/customers
        public IHttpActionResult Put([FromBody]CustomersRequest customersRequest)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                Customers newCustomer = new Customers();
                Mappers.MapRequestToNewCustomer(customersRequest, ref newCustomer);
                customerLogic.AddOne(newCustomer);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        //PATCH: /api/customers
        public IHttpActionResult Patch([FromBody]CustomersRequest customersRequest)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                Customers customer = customerLogic.GetOne(customersRequest.CustomerID);                
                Mappers.MapRequestToCustomer(customersRequest, ref customer);
                customerLogic.Update();
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
