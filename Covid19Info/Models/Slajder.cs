using System;
using System.Collections.Generic;

#nullable disable

namespace Covid19Info.Models
{
    public partial class Slajder
    {
        public int Id { get; set; }
        public string Podnaslov { get; set; }
        public string PodnaslovAl { get; set; }
        public string Sazetak { get; set; }
        public string SazetakAl { get; set; }
        public string Tekst { get; set; }
        public string TekstAl { get; set; }
        public string Slika { get; set; }
    }
}
