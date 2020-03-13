using ImagePro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePro.Service
{
    public interface IImageProHandler
    {
        ImageResult MultipleOperation(MultiOperation inputs);
        void LoadImage(String ImageStream);
        ImageResult FlipImage(FlipImage flipParam);
        ImageResult RotateImage(RotateImage rotate);
        ImageResult ResizeImage(ResizeImage resizeParam);
        ImageResult ThumbnailImage();
        ImageResult GrayScaleImage();
    }
}

