using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP4.Entities;
using TP4.Logic;
using Lab.MVC.Models;
using Lab.MVC.Controllers.Helpers;

namespace Lab.MVC.Controllers
{
    public class SupplierController : Controller
    {
        readonly ILogic<Suppliers> supplierLogic = new SupplierLogic();
        public ActionResult Index()
        {
            try
            {
                List<Suppliers> suppliers = supplierLogic.GetAll();
                List<SupplierView> suppliersView = Mappers.MapMultipleSuppliersToViews(suppliers);
                return View(suppliersView);
            }
            catch(Exception e)
            {
                ViewBag.ErrorTitle = "There was an error while trying to get the list of suppliers";
                return View("Error", e);
            }
        }

        public ActionResult Insert()
        {
            return View("FormSupplier");
        }
        [HttpPost]
        public ActionResult Insert(SupplierView supplierView)
        {
            try
            {
                if (supplierView.SupplierID == 0)
                {
                    Suppliers newSupplier = new Suppliers();
                    Mappers.MapViewToSupplier(supplierView, newSupplier);
                    supplierLogic.AddOne(newSupplier); 
                }
                else
                {
                    Suppliers supplierToUpdate = supplierLogic.GetOne(supplierView.SupplierID);
                    Mappers.MapViewToSupplier(supplierView, supplierToUpdate);
                    supplierLogic.Update();
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.ErrorTitle = "There was an error while trying to save the supplier";
                return View("Error", e);
            }
        }
        public ActionResult Update(int id)
        {
            try
            {
                Suppliers supplierToModify = supplierLogic.GetOne(id);
                SupplierView supplierView = Mappers.MapSupplierToView(supplierToModify);
                return View("FormSupplier",supplierView);
            }
            catch(Exception e)
            {
                ViewBag.ErrorTitle = "There was an error while trying get the supplier";
                return View("Error", e);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Suppliers supplierToDelete = supplierLogic.GetOne(id);
                supplierLogic.DeleteOne(supplierToDelete);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorTitle = "There was an error while trying to delete the supplier";
                return View("Error", e);
            }
        }
    }
}