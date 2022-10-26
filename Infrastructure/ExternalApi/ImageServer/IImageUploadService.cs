using Microsoft.AspNetCore.Http;
using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalApi.ImageServer
{
    public interface IImageUploadService
    {
        List<string> Upload(List<IFormFile> files);
    }
    public class ImageUploadService : IImageUploadService
    {
        public List<string> Upload(List<IFormFile> files)
        {

            var client = new RestClient("https://localhost:44372/api/images?apiKey=mySecretKey");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            foreach (var item in files)
            {
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    item.CopyTo(ms);
                    bytes = ms.ToArray();
                }
                request.AddFile(item.FileName, bytes, item.FileName, item.ContentType);
            }

            IRestResponse response = client.Execute(request);
            UploadDto upload = JsonConvert.DeserializeObject<UploadDto>(response.Content);
            return upload.FileNameAddress;
        }
    }


    public class UploadDto
    {
        public bool Status { get; set; }
        public List<string> FileNameAddress { get; set; }
    }
}
