using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using data = Finz__Frontend_.Models;


namespace Finz__Frontend_.Controllers
{
    public class DashboardController : Controller
    {

        string baseurl = "https://localhost:44398/";


        public async Task<IActionResult> Index()
        {
            List<data.Dinero> aux = new List<data.Dinero>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Dinero");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Dinero>>(auxres);
                }
            }
            ViewBag.userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(/*aux*/);
        }
    }
}
