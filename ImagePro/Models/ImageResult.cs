using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessor.Imaging.Filters.Photo;

namespace ImagePro.Models
{
    public class ImageResult
    {
        public string Message { get; set; }
        public byte[] Result { get; set; }
    }
    public class ImageStream
    {
        public string Imagestream { get; set; }
    }

    public class EnableParam
    {
        public bool Create { get; set; } = true;
    }

}
