using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVCSamples.Controllers
{
    public class PhotoController : Controller
    {
        //Get-Methode zum Anzeigen des Upload Formulares
        [HttpGet]
        public IActionResult UploadPicture()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadPicture(IFormFile datei)
        {
            FileInfo fileInfo = new FileInfo(datei.FileName);

            var speicherePfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + fileInfo.Name;

            using (var fs = new FileStream(speicherePfad, FileMode.Create))
            {
                datei.CopyTo(fs);
            }

            return RedirectToAction(nameof(UploadPicture));
        }

        public IActionResult Index ()
        {
            var pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";

            string[] bilder = Directory.GetFiles(pfad);

            return View(bilder);
        }

        public IActionResult IndexFormatted()
        {
            var pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";

            string[] bilder = Directory.GetFiles(pfad);

            return View(bilder);
        }
    }
}
