using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessor.Imaging.Filters.Photo;

namespace ImagePro.Models
{
    public class ImageResult
    {
        public byte[] result { get; set; }
        public string message { get; set; }
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
