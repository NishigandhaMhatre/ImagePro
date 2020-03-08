using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePro.Models
{
    public class ImageModel
    {
        public string ImageStream { get; set; } 
        public bool FlipVertically { get; set; }
        public bool FlipHorizontally { get; set; }
        public float RotateByDegrees { get; set; }
        public bool RotateLeft { get; set; } 
        public bool RotateRight { get; set; } 
    }
}
