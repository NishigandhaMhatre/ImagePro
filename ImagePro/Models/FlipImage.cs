using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePro.Models
{
    //=========================================
    // Model for flip image
    public class FlipImage : ImageStream
    {
        public FlipParam Param { get; set; }
    }
    public class FlipParam
    {
        public bool FlipVertically { get; set; }
        public bool FlipHorizontally { get; set; }
    }
}
