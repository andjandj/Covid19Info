using Covid19Info.Models;
using Covid19Info.Services;
using Covid19Info.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Info.Controllers
{
    public class VestiController : Controller
    {
        private readonly Covid19InfoContext _context;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public VestiController(Covid19InfoContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            WebHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        public IActionResult Index()
        {
           List<Vesti> vesti = (from v in _context.Vestis
                           select v).ToList();
            return View(vesti);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VestiViewModel model)
        {
            string fileName = VestiServices.UploadFile(model, WebHostEnvironment);
            if (ModelState.IsValid)
            {
                var vest = new Vesti
                {
                    Naslov = model.Naslov,
                    NaslovAl = model.NaslovAl,
                    Datum = model.Datum,
                    Sazetak = model.Sazetak,
                    SazetakAl = model.SazetakAl,
                    Tekst = model.Tekst,
                    TekstAl = model.TekstAl,
                    Slika = fileName,
                    Imunizacija = model.Imunizacija,
                };

                _context.Vestis.Add(vest);
                _context.SaveChanges();
                ViewBag.Msg = "Uspesno ubaceno";
                return View();

            }
            else
            {
                ViewBag.Msg = "Nije ubaceno";
                return BadRequest();
            }
        }

        public IActionResult Details(int id)
        {
            Vesti vest = _context.Vestis.Find(id);

            return View(vest);
        }

        public IActionResult Delete(int id)
        {
            Vesti vest = _context.Vestis.Find(id);
            try
            {
                _context.Vestis.Remove(vest);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            VestiViewModel vest = (from v in _context.Vestis
                                    where v.Id == id
                                    select new VestiViewModel { Naslov = v.Naslov, NaslovAl = v.NaslovAl, Sazetak = v.Sazetak,
                                    SazetakAl = v.SazetakAl, Tekst = v.Tekst, TekstAl = v.TekstAl, Imunizacija = v.Imunizacija, Datum = v.Datum}).FirstOrDefault();
            return View(vest);
        }

        public IActionResult Edit(int id,VestiViewModel model)
        {
            Vesti vest = _context.Vestis.Find(id);
            vest.Naslov = model.Naslov;
            vest.NaslovAl = model.NaslovAl;
            vest.Sazetak = model.Sazetak;
            vest.SazetakAl = model.SazetakAl;
            vest.Tekst = model.Tekst;
            vest.TekstAl = model.TekstAl;
            vest.Imunizacija = model.Imunizacija;
            vest.Datum = model.Datum;

            try
            {
                _context.Vestis.Update(vest);
                _context.SaveChanges();
                ViewBag.Msg = "Uspesno izmenjeno";
                return View();
            }
            catch
            {
                throw;
            }

        }
        //public string UploadFile(VestiViewModel model, IWebHostEnvironment web)
        //{

        //    string fileName = null;


        //    if (model.Slika != null)
        //    {
        //        string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Images");
        //        fileName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
        //        string filePath = Path.Combine(uploadDir, fileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.Slika.CopyTo(fileStream);
        //        }

                
        //    }

        //    return fileName;
        //}

    }
}
