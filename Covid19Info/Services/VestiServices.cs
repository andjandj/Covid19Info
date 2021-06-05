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
    }
}
