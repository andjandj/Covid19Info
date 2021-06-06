using Covid19Info.Models;
using Covid19Info.Services;
using Covid19Info.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Info.Controllers
{
    public class SlajderController : Controller
    {
        private readonly Covid19InfoContext _context;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public SlajderController(Covid19InfoContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            WebHostEnvironment = webHostEnvironment;

        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_context.Slajders.ToList());
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SlajderViewModel model)
        {
            string fileName = SlajderService.UploadFile(model, WebHostEnvironment);
            Slajder slajder = new Slajder
            {
                Podnaslov = model.Podnaslov,
                PodnaslovAl = model.PodnaslovAl,
                Sazetak = model.Sazetak,
                SazetakAl = model.SazetakAl,
                Tekst = model.Tekst,
                TekstAl = model.TekstAl,
                Slika = fileName,
            };

            try
            {
                _context.Slajders.Add(slajder);
                _context.SaveChanges();
                return View();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            return View(_context.Slajders.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, SlajderViewModel model)
        {
            Slajder slajder = _context.Slajders.Find(id);

            slajder.Podnaslov = model.Podnaslov;
            slajder.PodnaslovAl = model.PodnaslovAl;
            slajder.Sazetak = model.Sazetak;
            slajder.SazetakAl = model.SazetakAl;
            slajder.Tekst = model.Tekst;
            slajder.TekstAl = model.TekstAl;

            try
            {
                _context.Slajders.Update(slajder);
                _context.SaveChanges();
                return View();
            }
            catch
            {
                throw;
            }
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            Slajder slajder = _context.Slajders.Find(id);
            return View(slajder);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            Slajder slajder = _context.Slajders.Find(id);
            try
            {
                _context.Slajders.Remove(slajder);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }
    }
}
