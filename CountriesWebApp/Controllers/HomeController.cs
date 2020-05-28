using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountriesWebApp.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns frontend.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // = ~/Views/Home/Index.cshtml
        }
    }
}