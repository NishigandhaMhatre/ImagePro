using System;
using System.Drawing;
using ImagePro.Models;
using System.IO;
using ImageProcessor;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using ImagePro.Service;

namespace ImagePro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private ImageProHandler ImageProHandler { get; set; }
        public ImageController()
        {
            ImageProHandler = new ImageProHandler();
        }

        /// <summary>
        /// Perform multiple operations as per the given operation sequence in parameteres
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        [HttpPost(ApiRoute.MULTIPLEOPERATION)]
        [ProducesResponseType(typeof(ImageResult), 200)]
        [ProducesResponseType(typeof(EmptyInputError), 400)]
        [ProducesResponseType(typeof(InvalidOperationError), 405)]
        [ProducesResponseType(typeof(InvalidInputParameterError), 409)]
        [ProducesResponseType(404)]
        public IActionResult MultipleOperation([FromBody] MultiOperation inputs)
        {
            if (inputs == null || inputs.Imagestream == null || inputs.MultiOperationParam== null)
            {
                return StatusCode(400, new EmptyInputError() { });
            }
            ImageProHandler.LoadImage(inputs.Imagestream);
            var response = ImageProHandler.MultipleOperation(inputs);
            ImageProHandler.outStream.Close();
            ImageProHandler.inStream.Close();
            if (response.Message == OpMessage.InvalidOperation)
            {
                return StatusCode(405, new InvalidOperationError() { });
            }
            else if (response.Message == OpMessage.InvalidInputParameter)
            {
                return StatusCode(409, new InvalidInputParameterError() { });
            }
            return Ok(response);
        }

        /// <summary>
        /// Perform Image flip operations as per the given parameteres
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        [HttpPost(ApiRoute.FLIP)]
        [ProducesResponseType(typeof(ImageResult), 200)]
        [ProducesResponseType(typeof(EmptyInputError), 400)]
        [ProducesResponseType(typeof(InvalidOperationError), 405)]
        [ProducesResponseType(typeof(InvalidInputParameterError), 409)]
        [ProducesResponseType(404)]
        public IActionResult FlipImage([FromBody] FlipImage inputs)
        {
            ImageProHandler.LoadImage(inputs.Imagestream);
            var response = ImageProHandler.FlipImage(inputs);
            ImageProHandler.outStream.Close();
            ImageProHandler.inStream.Close();
            if (response.Message == OpMessage.InvalidOperation)
            {
                return StatusCode(405, new InvalidOperationError() { });
            }
            else if (response.Message == OpMessage.InvalidInputParameter)
            {
                return StatusCode(409, new InvalidInputParameterError() { });
            }
            return Ok(response);
        }

        /// <summary>
        /// Perform Image rotate operations as per the given parameteres
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        [HttpPost(ApiRoute.ROTATE)]
        [ProducesResponseType(typeof(ImageResult), 200)]
        [ProducesResponseType(typeof(EmptyInputError), 400)]
        [ProducesResponseType(typeof(InvalidOperationError), 405)]
        [ProducesResponseType(typeof(InvalidInputParameterError), 409)]
        [ProducesResponseType(404)]
        public IActionResult RotateImage([FromBody] RotateImage inputs)
        {
            ImageProHandler.LoadImage(inputs.Imagestream);
            var response = ImageProHandler.RotateImage(inputs);
            ImageProHandler.outStream.Close();
            ImageProHandler.inStream.Close();
            if (response.Message == OpMessage.InvalidOperation)
            {
                return StatusCode(405, new InvalidOperationError() { });
            }
            else if (response.Message == OpMessage.InvalidInputParameter)
            {
                return StatusCode(409, new InvalidInputParameterError() { });
            }
            return Ok(response);
        }

        /// <summary>
        /// Perform Image resize operations as per the given parameteres
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        [HttpPost(ApiRoute.RESIZE)]
        [ProducesResponseType(typeof(ImageResult), 200)]
        [ProducesResponseType(typeof(EmptyInputError), 400)]
        [ProducesResponseType(typeof(InvalidOperationError), 405)]
        [ProducesResponseType(typeof(InvalidInputParameterError), 409)]
        [ProducesResponseType(404)]
        public IActionResult ResizeImage([FromBody] ResizeImage inputs)
        {
            ImageProHandler.LoadImage(inputs.Imagestream);
            var response = ImageProHandler.ResizeImage(inputs);
            ImageProHandler.outStream.Close();
            ImageProHandler.inStream.Close();
            if (response.Message == OpMessage.InvalidOperation)
            {
                return StatusCode(405, new InvalidOperationError() { });
            }
            else if (response.Message == OpMessage.InvalidInputParameter)
            {
                return StatusCode(409, new InvalidInputParameterError() { });
            }
            return Ok(response);
        }

        /// <summary>
        /// Perorms Image thumbnail gemerATION operations
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        [HttpPost(ApiRoute.THUMBNAIL)]
        [ProducesResponseType(typeof(ImageResult), 200)]
        [ProducesResponseType(typeof(EmptyInputError), 400)]
        [ProducesResponseType(typeof(InvalidOperationError), 405)]
        [ProducesResponseType(typeof(InvalidInputParameterError), 409)]
        [ProducesResponseType(404)]
        public IActionResult ThumbnailImage([FromBody] ImageStream inputs)
        {
            ImageProHandler.LoadImage(inputs.Imagestream);
            var response = ImageProHandler.ThumbnailImage();
            ImageProHandler.outStream.Close();
            ImageProHandler.inStream.Close();
            if (response.Message == OpMessage.InvalidOperation)
            {
                return StatusCode(405, new InvalidOperationError() { });
            }
            else if (response.Message == OpMessage.InvalidInputParameter)
            {
                return StatusCode(409, new InvalidInputParameterError() { });
            }
            return Ok(response);
        }

        /// <summary>
        /// Performs Image grayscale generation operation
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        [HttpPost(ApiRoute.GRAYSCALE)]
        [ProducesResponseType(typeof(ImageResult), 200)]
        [ProducesResponseType(typeof(EmptyInputError), 400)]
        [ProducesResponseType(typeof(InvalidOperationError), 405)]
        [ProducesResponseType(typeof(InvalidInputParameterError), 409)]
        [ProducesResponseType(404)]
        public IActionResult ConvertGreyScale([FromBody] ImageStream inputs)
        {
            ImageProHandler.LoadImage(inputs.Imagestream);
            var response = ImageProHandler.GrayScaleImage();
            ImageProHandler.outStream.Close();
            ImageProHandler.inStream.Close();
            if (response.Message == OpMessage.InvalidOperation)
            {
                return StatusCode(405, new InvalidOperationError() { });
            }
            else if (response.Message == OpMessage.InvalidInputParameter)
            {
                return StatusCode(409, new InvalidInputParameterError() { });
            }
            return Ok(response);
        }

  
    }
}