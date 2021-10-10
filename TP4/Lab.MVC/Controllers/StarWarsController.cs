using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Lab.External.Logic;
using Lab.External.Models;

namespace Lab.MVC.Controllers
{
    public class StarWarsController : Controller
    {
        readonly StarWarsApiLogic starWarsLogic = new StarWarsApiLogic();
        public async Task<ActionResult> IndexPage(string pageUrl)
        {
            try
            {
                PeopleResponse people = await starWarsLogic.GetPeopleAsync(pageUrl);
                return View("Index", people);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorTitle = "There was an error while trying to get the list of characters";
                return View("Error", ex);
            }
        }
    }
}