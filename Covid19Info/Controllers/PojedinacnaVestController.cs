using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Covid19Info.Controllers
{
    public class PojedinacnaVestController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PojedinacnaVest()
        {
            return View();
        }
   
    }
}
