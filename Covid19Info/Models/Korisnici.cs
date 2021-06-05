using System;
using System.Collections.Generic;

#nullable disable

namespace Covid19Info.Models
{
    public partial class Korisnici
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Email { get; set; }
        public string NaslovPoruke { get; set; }
        public string Poruka { get; set; }
    }
}
