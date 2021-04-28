using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finz__Frontend_.Controllers
{
    public class IncomesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
