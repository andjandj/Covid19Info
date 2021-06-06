using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Info.ViewModels
{
    public class SlajderViewModel
    {
        public string Podnaslov { get; set; }
        public string PodnaslovAl { get; set; }
        public string Sazetak { get; set; }
        public string SazetakAl { get; set; }
        public string Tekst { get; set; }
        public string TekstAl { get; set; }
        public IFormFile Slika { get; set; }
    }
}
