using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using System.IO;

namespace XYJPersonalSite.Controllers
{
    public class FileController : Controller
    {
        private readonly IHostingEnvironment _environment;
        public FileController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult UploadFiles(IList<IFormFile> files)
        {
            long size = 0;
            string filename=string.Empty;
            foreach (var file in files)
            {
                filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                string extension = filename.Substring(filename.LastIndexOf('.'));
                filename = Path.Combine(_environment.WebRootPath, "images");
                filename = Path.Combine(filename, "article_images");
                filename = (Path.Combine(filename, DateTime.Now.ToFileTime().ToString()+extension));       
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return Content(filename);
        }
    }
}