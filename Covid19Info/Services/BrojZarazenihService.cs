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
        public static List<BrojZarazenihOsoba> listBrojZarazenihOsobaRegion(string region)
        {
            int idMax = (from i in _context.BrojZarazenihOsobas
                         select i.Id).Max();
            List<BrojZarazenihOsoba> brZarazenihOsoba = (from br in _context.BrojZarazenihOsobas
                                                         where br.DeoNaKojiSePodaciOdnose == region && br.Id == idMax
                                                         select br).ToList();
            return brZarazenihOsoba;
        }
    }
}
