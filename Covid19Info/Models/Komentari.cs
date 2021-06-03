using System;
using System.Collections.Generic;

#nullable disable

namespace Covid19Info.Models
{
    public partial class Komentari
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string TekstKomentara { get; set; }
        public int? IdVest { get; set; }
    }
}
