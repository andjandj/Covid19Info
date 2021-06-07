using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19Info.Models;
using Covid19Info.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Covid19Info.Controllers
{
    public class PojedinacnaVestController : Controller
    {
        private readonly Covid19InfoContext _context;
        public PojedinacnaVestController(Covid19InfoContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Index(int id,KomentariViewModel model)
        {
            Komentari komentar = new Komentari
            {
                KorisnickoIme = model.KorisnickoIme,
                Email = model.Email,
                TekstKomentara = model.TekstKomentara,
                IdVest = id,
            };

            try
            {
                _context.Komentaris.Add(komentar);
                _context.SaveChanges();
                return View();
            }
            catch
            {
               // throw;
                ViewBag.Msg = "Došlo je do greške, komentar nije poslat";
                return View();
            }
        }
   
    }
}
