using Covid19Info.Models;
using Covid19Info.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Info.Controllers
{
    public class BrojZarazenihController : Controller
    {
        private readonly Covid19InfoContext _context;

        public BrojZarazenihController(Covid19InfoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<BrojZarazenihOsoba> brOsobaLista = _context.BrojZarazenihOsobas.ToList();
            return View(brOsobaLista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BrojZarazenihOsobaViewModel model)
        {
            BrojZarazenihOsoba brZarazenih = new BrojZarazenihOsoba
            {
                BrojTestiranihOsobaDnevno = model.BrojTestiranihOsobaDnevno,
                BrojPotvrdjenihSlucajeva = model.BrojPotvrdjenihSlucajeva,
                BrojSmrtnihSlucajeva = model.BrojSmrtnihSlucajeva,
                UkupanBrojTestiranihSlucajeva = model.UkupanBrojTestiranihSlucajeva,
                DatumTestiranja = model.DatumTestiranja,
                DeoNaKojiSePodaciOdnose = model.DeoNaKojiSePodaciOdnose,

            };
            try
            {
                _context.BrojZarazenihOsobas.Add(brZarazenih);
                _context.SaveChanges();
                ViewBag.Msg = "Uspesno ubaceno";
                return View();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.BrojZarazenihOsobas.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, BrojZarazenihOsobaViewModel model)
        {
            BrojZarazenihOsoba brZarazenih = _context.BrojZarazenihOsobas.Find(id);

            brZarazenih.BrojPotvrdjenihSlucajeva = model.BrojPotvrdjenihSlucajeva;
            brZarazenih.BrojSmrtnihSlucajeva = model.BrojSmrtnihSlucajeva;
            brZarazenih.BrojTestiranihOsobaDnevno = model.BrojTestiranihOsobaDnevno;
            brZarazenih.DatumTestiranja = model.DatumTestiranja;
            brZarazenih.DeoNaKojiSePodaciOdnose = model.DeoNaKojiSePodaciOdnose;
            brZarazenih.UkupanBrojTestiranihSlucajeva = model.UkupanBrojTestiranihSlucajeva;

            try
            {
                _context.BrojZarazenihOsobas.Update(brZarazenih);
                _context.SaveChanges();
                ViewBag.Msg = "Uspesno odradjene izmene";
                return View();
            }
            catch
            {
                throw;
            }
        }

        public IActionResult Details(int id)
        {
            BrojZarazenihOsoba brZarazenih = _context.BrojZarazenihOsobas.Find(id);
            return View(brZarazenih);
        }

        public IActionResult Delete(int id)
        {
            BrojZarazenihOsoba brZarazenih = _context.BrojZarazenihOsobas.Find(id);
            try
            {
                _context.BrojZarazenihOsobas.Remove(brZarazenih);
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
