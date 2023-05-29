using EndPintFileStatic.Controllers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalApi.ImgeServer
{
    // ma inja mikhaim ks ro to server upload konim va scr ro or sh begirim
    public interface ImageUploderService
    {

        List<string> upload(List<IFormFile> files);
    }
    public class mageUploderService : ImageUploderService
    {

        
             public List<string> upload(List<IFormFile> files)
        {

           
            var client = new RestClient("https://localhost:44321/api/Images?Apikey=ApiKey");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            foreach (var item in files)
            {
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    item.CopyToAsync(ms);
                    bytes = ms.ToArray();
                }
                request.AddFile(item.FileName, bytes, item.FileName, item.ContentType);
            }


            IRestResponse response = client.Execute(request);
            UploadDto upload = JsonConvert.DeserializeObject<UploadDto>(response.Content);
            return upload.FileNameAddress;

        }
    }

}
