using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePro.Models
{
    //=========================================
    // Model for Rotate image
    public class RotateImage : ImageStream
    {
        public RotateParam Param { get; set; }
    }

    public class RotateParam
    {
        public float RotateByDegrees { get; set; }
        public bool RotateLeft { get; set; }
        public bool RotateRight { get; set; }
    }

}
