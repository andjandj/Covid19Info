using System;
using System.Collections.Generic;

#nullable disable

namespace Covid19Info.Models
{
    public partial class BrojZarazenihOsoba
    {
        public int Id { get; set; }
        public int? BrojTestiranihOsobaDnevno { get; set; }
        public int? BrojPotvrdjenihSlucajeva { get; set; }
        public int? BrojSmrtnihSlucajeva { get; set; }
        public int? UkupanBrojTestiranihSlucajeva { get; set; }
        public DateTime? DatumTestiranja { get; set; }
        public string DeoNaKojiSePodaciOdnose { get; set; }
    }
}
