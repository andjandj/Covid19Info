using System;
using System.Collections.Generic;

#nullable disable

namespace Covid19Info.Models
{
    public partial class Vesti
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string NaslovAl { get; set; }
        public DateTime? Datum { get; set; }
        public string Sazetak { get; set; }
        public string SazetakAl { get; set; }
        public string Tekst { get; set; }
        public string TekstAl { get; set; }
        public string Slika { get; set; }
        public int? Imunizacija { get; set; }
    }
}
