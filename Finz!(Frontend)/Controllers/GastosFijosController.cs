using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Finz__Frontend_.Models;
using System.Net.Http;
using Newtonsoft.Json;
using data = Finz__Frontend_.Models;


namespace Finz__Frontend_.Controllers
{
    public class GastosFijosController : Controller
    {
        string baseurl = "https://localhost:44398/";


        // GET: GastosFijos
        public async Task<IActionResult> Index()
        {
            List<data.GastosFijos> aux = new List<data.GastosFijos>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/GastosFijos");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.GastosFijos>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: GastosFijos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastosFijos = GetById(id);


            if (gastosFijos == null)
            {
                return NotFound();
            }

            return View(gastosFijos);
        }

        // GET: GastosFijos/Create
        public IActionResult Create()
        {
            //ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: GastosFijos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGastoFijo,Nombre,Valor,IdUsuario")] GastosFijos gastosFijos)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(gastosFijos);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/GastosFijos", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            //ViewData["GroupUpdateId"] = new SelectList(GetAllGroupUpdates(), "GroupUpdateId", "GroupUpdateId", groupComment.GroupUpdateId);
            return View(gastosFijos);
        }

        // GET: GastosFijos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastosFijos = GetById(id);
            if (gastosFijos == null)
            {
                return NotFound();
            }
            return View(gastosFijos);
        }

        // POST: GastosFijos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGastoFijo,Nombre,Valor,IdUsuario")] GastosFijos gastosFijos)
        {
            if (id != gastosFijos.IdGastoFijo)
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
                        var content = JsonConvert.SerializeObject(gastosFijos);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/GastosFijos/" + id, byteContent).Result;

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
            return View(gastosFijos);
        }

        // GET: GastosFijos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastosFijos = GetById(id);
            if (gastosFijos == null)
            {
                return NotFound();
            }

            return View(gastosFijos);
        }

        // POST: GastosFijos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/GastosFijos/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool GastosFijosExists(int id)
        {
            return (GetById(id) != null);
        }

        private data.GastosFijos GetById(int? id)
        {
            data.GastosFijos aux = new data.GastosFijos();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/GastosFijos/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.GastosFijos>(auxres);
                }
            }
            return aux;
        }
    }
}
