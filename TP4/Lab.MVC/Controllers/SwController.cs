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
    public class SwController : Controller
    {

        // GET: People
        public async Task<ActionResult> Index()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://swapi.dev/api/");
                var responseTask = await httpClient.GetStringAsync("people");

                var people = JsonConvert.DeserializeObject<PeopleResponse>(responseTask);

               /* HttpResponseMessage response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    Task<PeopleResponse[]>readTask = response.Content.ReadAsAsync<PeopleResponse[]>();
                    PeopleResponse[] people = readTask.Result;
                    */return View(people);
                /*}
                return View("Error");*/
            }
            
        }
    }
}