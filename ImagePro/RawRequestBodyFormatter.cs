using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
namespace ImagePro
{
    internal class RawRequestBodyFormatter: InputFormatter
    {
        public RawRequestBodyFormatter()
        {

            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/bmp"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/gif"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpg"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/png"));

        }


        /// <summary>
        /// Allow text/plain, application/octet-stream and no content type to
        /// be processed
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool CanRead(InputFormatterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var contentType = context.HttpContext.Request.ContentType;

            var supported = contentType == "image/bmp" || contentType == "image/gif" || contentType == "image/jpeg" || contentType == "image/jpg" || contentType == "image/png";

            return supported;
        }

        /// <summary>
        /// Handle text/plain or no content type for string results
        /// Handle application/octet-stream for byte[] results
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {

            var request = context.HttpContext.Request;
            var contentType = context.HttpContext.Request.ContentType;


            if (contentType == "image/bmp" || contentType == "image/gif" || contentType == "image/jpeg" || contentType == "image/jpg" || contentType == "image/png")
            {
                using (var ms = new MemoryStream(2048))
                {
                    await request.Body.CopyToAsync(ms);
                    var content = ms.ToArray();

                    return await InputFormatterResult.SuccessAsync(content);
                }
            }

            return await InputFormatterResult.FailureAsync();
        }
    }
}