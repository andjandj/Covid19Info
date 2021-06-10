using Covid19Info.Models;
using Covid19Info.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Info.Services
{
    public class VestiServices
    {
        public static readonly Covid19InfoContext _context =  new Covid19InfoContext();
      
        public static string UploadFile(VestiViewModel model, IWebHostEnvironment web)
        {

            string fileName = null;


            if (model.Slika != null)
            {
                string uploadDir = Path.Combine(web.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Slika.CopyTo(fileStream);
                }


            }

            return fileName;
        }

        public static List<Vesti> ListOfVesti()
        {
            List<Vesti> vesti = (from v in _context.Vestis
                                 select v).OrderByDescending(e => e.Id).ToList();
            return vesti;
        }

        public static Vesti JednaVest(int? id)
        {
            Vesti vest = new Vesti();
            if (id == null) 
            { 
                int idMax = (from v in _context.Vestis
                             select v.Id).Max();

                vest = (from v in _context.Vestis
                        where v.Id == idMax
                        select v).Single();
            }
            else
            {
                vest = (from v in _context.Vestis
                        where v.Id == id
                        select v).Single();
            }
            return vest;
        }
    }
}
