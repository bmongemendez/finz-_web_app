using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Finz__Frontend_.Models;
using data = Finz__Frontend_.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Finz__Frontend_.Controllers
{
    public class AhorrosController : Controller
    {

        string baseurl = "https://localhost:44398/";

        // GET: Ahorros
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Ahorros.ToListAsync());

            List<data.Ahorros> aux = new List<data.Ahorros>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Ahorros");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Ahorros>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: Ahorros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ahorros = GetById(id);


            if (ahorros == null)
            {
                return NotFound();
            }

            return View(ahorros);
        }

        // GET: Ahorros/Create
        public IActionResult Create()
        {
            ViewBag.userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View();

        }

        // POST: Ahorros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAhorros,AhorrosAcutales,IdUsuario,IdCategoria")] Ahorros ahorros)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(ahorros);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/Ahorros", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            //ViewData["GroupUpdateId"] = new SelectList(GetAllGroupUpdates(), "GroupUpdateId", "GroupUpdateId", groupComment.GroupUpdateId);
            return View(ahorros);
        }

        // GET: Ahorros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ahorros = GetById(id);
            if (ahorros == null)
            {
                return NotFound();
            }

            ViewBag.userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);


            return View(ahorros);
        }

        // POST: Ahorros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAhorros,AhorrosAcutales,IdUsuario,IdCategoria")] Ahorros ahorros)
        {
            if (id != ahorros.IdAhorros)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(baseurl);
                        var content = JsonConvert.SerializeObject(ahorros);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/Ahorros/" + id, byteContent).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception)
                {
                    var aux2 = GetById(id);
                    if (aux2 == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["GroupUpdateId"] = new SelectList(GetAllGroupUpdates(), "GroupUpdateId", "GroupUpdateId", groupComment.GroupUpdateId);
            return View(ahorros);
        }

        // GET: Ahorros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ahorros = GetById(id);
            if (ahorros == null)
            {
                return NotFound();
            }

            return View(ahorros);
        }

        // POST: Ahorros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/Ahorros/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AhorrosExists(int id)
        {
            return (GetById(id) != null);
        }


        private data.Ahorros GetById(int? id)
        {
            data.Ahorros aux = new data.Ahorros();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/Ahorros/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.Ahorros>(auxres);
                }
            }
            return aux;
        }
    }
}
