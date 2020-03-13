using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePro.Models
{
    public class Operations
    {
        public const string FLIP = "FLIP";
        public const string ROTATE = "ROTATE";
        public const string RESIZE = "RESIZE";
        public const string GRAYSCALE = "GRAYSCALE";
        public const string THUMBNAIL = "THUMBNAIL";
    }

    public class OpMessage
    {
        public const string Success = "FLIP";
        public const string InvalidOperation = "InvalidOperationError";
        public const string InvalidInputParameter = "InvalidInputParameterError";
    }
}
