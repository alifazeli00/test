using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;

namespace EndPintFileStatic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImagesController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        public IActionResult Post(string Apikey)
        {

            if(Apikey!="ApiKey")
            {

                return BadRequest();
            }
            try
            {
                var file = Request.Form.Files;
                var folderName = Path.Combine("Resources ","Images");
                var pathToSave=Path.Combine(Directory.GetCurrentDirectory(),folderName); // masir

                if(file!=null)
                {
                    return Ok(UploadFile(file));
                }
                else { return BadRequest(); }
            }
            catch(Exception ex)
            {


                return StatusCode(500, $"server error");
                throw new Exception(" uplod error", ex);
            }

        }
        private  UploadDto  UploadFile(IFormFileCollection files)
        {
            string newNme =  Guid.NewGuid().ToString(); // masan age be on sorat ke feresede bod va esm tekrari bod bayad jolosh geref
            var Date = DateTime.Now;

            string folder = $@"Resources\images\{Date.Year}\{Date.Year}-{Date.Month}\";
            var uploadsRootFolder = Path.Combine(_hostingEnvironment.WebRootPath, folder);
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }
            List<string> address = new List<string>();
            
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    string fileName = newNme + file.FileName;
                    var filePath = Path.Combine(uploadsRootFolder, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    address.Add(folder + fileName);
                }
            }

            return new UploadDto()
            {
                FileNameAddress = address,
                Status = true,
            };



        }
    }
public class UploadDto
    {

        public bool  Status { get; set; }
        public List<string> FileNameAddress { get; set; }
    }
}
