using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Info.ViewModels
{
    public class BrojZarazenihOsobaViewModel
    {
        public int? BrojTestiranihOsobaDnevno { get; set; }
        public int? BrojPotvrdjenihSlucajeva { get; set; }
        public int? BrojSmrtnihSlucajeva { get; set; }
        public int? UkupanBrojTestiranihSlucajeva { get; set; }
        public DateTime? DatumTestiranja { get; set; }
        public string DeoNaKojiSePodaciOdnose { get; set; }
    }
}
