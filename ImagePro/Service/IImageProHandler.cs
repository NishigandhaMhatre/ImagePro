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
        byte[] FlipImage(FlipImage flipParam);
        byte[] RotateImage(RotateImage rotate);
        byte[] ResizeImage(ResizeImage resizeParam);
        byte[] ThumbnailImage();
        byte[] GrayScaleImage();
    }
}

