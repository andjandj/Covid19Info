using Covid19Info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Info.Services
{
    public class BrojZarazenihService
    {
        public static Covid19InfoContext _context = new Covid19InfoContext();
        public static BrojZarazenihOsoba listBrojZarazenihOsobaRegion(string region)
        {
            int idMax = (from i in _context.BrojZarazenihOsobas
                         where i.DeoNaKojiSePodaciOdnose == region
                         select i.Id).Max();
            BrojZarazenihOsoba brZarazenihOsoba = (from br in _context.BrojZarazenihOsobas
                                                         where br.Id == idMax
                                                         select br).Single();
            return brZarazenihOsoba;
        }
    }
}
