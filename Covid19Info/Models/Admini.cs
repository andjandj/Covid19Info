﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Covid19Info.Models
{
    public partial class Admini
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string Telefon { get; set; }
    }
}
