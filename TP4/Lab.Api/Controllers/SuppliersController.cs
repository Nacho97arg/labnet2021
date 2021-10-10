using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TP4.Logic;
using TP4.Entities;
using Lab.Api.Models;
using Lab.Api.Controllers.Helpers;

namespace Lab.Api.Controllers
{
    public class SuppliersController : ApiController
    {
        private readonly ILogic<Suppliers,int> supplierLogic = new SupplierLogic();
        //GET: /api/suppliers
        public IHttpActionResult Get()
        {
            try
            {
                List<Suppliers> suppliers = supplierLogic.GetAll();
                List<SuppliersResponse> suppliersResponses = Mappers.MapListMapMultipleSuppliersToResponses(suppliers);
                return Json(suppliersResponses);                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        //GET: /api/suppliers/{id}
        public IHttpActionResult Get(int id)
        {
            try
            {
                Suppliers supplier = supplierLogic.GetOne(id);
                if (supplier == null) return NotFound();

                SuppliersResponse supplierResponse = Mappers.MapSupplierToResponse(supplier);
                return Json(supplierResponse);              
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        //DELETE: /api/suppliers/{id}
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Suppliers supplierToDelete = supplierLogic.GetOne(id);
                if (supplierToDelete == null) return NotFound();

                supplierLogic.DeleteOne(supplierToDelete);
                return Ok();                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        //PUT: /api/suppliers
        /// <summary>
        /// Inserts a new supplier or modifies one depending on the value of the given id.
        /// </summary>
        /// <param name="suppliersRequest"></param>
        /// <returns></returns>
        public IHttpActionResult Put([FromBody] SuppliersRequest suppliersRequest)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if(suppliersRequest.SupplierID != 0)
                {
                    Suppliers supplier = supplierLogic.GetOne(suppliersRequest.SupplierID);
                    Mappers.MapRequestToSupplier(suppliersRequest, ref supplier);
                    supplierLogic.Update();
                    return Ok();
                }
                else
                {
                    Suppliers newSupplier = new Suppliers();
                    Mappers.MapRequestToSupplier(suppliersRequest, ref newSupplier);
                    supplierLogic.AddOne(newSupplier);
                    return Ok();
                }            
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
