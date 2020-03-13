using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePro.Models
{
    //=========================================
    // Model for Resize image
    public class ResizeImage : ImageStream
    {
        public ResizeParam Param { get; set; }
    }

    public class ResizeParam
    {
        public int Heigth { get; set; }
        public int Width { get; set; }
    }

}
