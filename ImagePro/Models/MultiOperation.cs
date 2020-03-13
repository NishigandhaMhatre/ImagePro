using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePro.Models
{
    public class MultiOperation : ImageStream
    {
        public MultiOperationParam MultiOperationParam { get; set; }
    }

    public class MultiOperationParam
    {
        public List<string> MultiOperationSequence { get; set; }
        public List<FlipParam> FlipParam { get; set; }
        public List<RotateParam> RotateParam { get; set; }
        public List<ResizeParam> ResizeParam { get; set; }
        public List<EnableParam> GreyScaleParam { get; set; }
        public List<EnableParam> ThumbnailParam { get; set; }
    }

}
