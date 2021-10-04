using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using Lab.MVC.Models;
using Newtonsoft.Json;

namespace Lab.MVC.Controllers
{
    public class StarWarsController : Controller
    {

        // GET: People
        public async Task<ActionResult> Index()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://swapi.dev/api/");
                    var responseTask = await httpClient.GetStringAsync("people");

                    var peopleResponse = JsonConvert.DeserializeObject<PeopleResponse>(responseTask);
                    return View(peopleResponse);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);                
            }
            
        }
    }
}