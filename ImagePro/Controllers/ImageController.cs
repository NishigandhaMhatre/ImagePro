using System;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using ImagePro.Models;
using System.IO;
using ImageProcessor;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ImagePro.Controllers
{
    [Route("[controller]")]
    public class ImageController : Controller
    {
        private ImageProHandler ImageProHandler;
        private readonly ILogger logger;

        public ImageController()
        {
            ImageProHandler = new ImageProHandler();
        }

        [HttpGet("/test")]
        public void FlipImage()
        {
            Console.WriteLine("GET method triggered");
        }

        [HttpPost("/flip")]
        [ProducesResponseType(typeof(Image), 200)]
        public async Task<InputFormatterResult> FlipImage([FromBody] ImageModel imagePro)
        {
   
            var imageStr = imagePro.ImageStream;
            ImageProHandler.LoadImage(imageStr);
            var FlipImage = ImageProHandler.FlipImage(false, true);
            ImageProHandler.outStream.Close();
            ImageProHandler.inStream.Close();
            return await InputFormatterResult.SuccessAsync(FlipImage);


        }
    }
}