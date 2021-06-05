using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Info.ViewModels
{
    public class VestiViewModel
    {
        public string Naslov { get; set; }
        public string NaslovAl { get; set; }
        public DateTime? Datum { get; set; }
        public string Sazetak { get; set; }
        public string SazetakAl { get; set; }
        public string Tekst { get; set; }
        public string TekstAl { get; set; }
        public IFormFile Slika { get; set; }
        public int? Imunizacija { get; set; }
    }
}
