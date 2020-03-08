using ImageProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePro.Models
{
    public class ImageProHandler : ImageModel
    {
        
        public new string ImageStream { get; set; } = "Initial";

        public new bool FlipVertically { get; set; } = false;
        public new bool FlipHorizontally { get; set; } = false;
        public new float RotateByDegrees { get; set; } = 0;
        public new bool RotateLeft { get; set; } = false;
        public new bool RotateRight { get; set; } = false;

        //object of the ImageFactory class
        public ImageFactory imageFactory = new ImageFactory(preserveExifData: true);

        //variables to store image in memory
        public MemoryStream inStream = new MemoryStream();
        public MemoryStream outStream = new MemoryStream();

        /// <summary>
        /// Method to laod Image in memory
        /// </summary>
        /// <param name="ImageStream"></param>
        public void LoadImage(String ImageStream)
        {
            byte[] bytes = Convert.FromBase64String(ImageStream);
            inStream = new MemoryStream(bytes);
            imageFactory.Load(inStream);
       
        }

        public byte[] FlipImage(bool FlipVertically, bool FlipHorizontally)
        {
            imageFactory.Flip(FlipVertically, FlipHorizontally)
                        .Save(outStream);
            var Content = outStream.ToArray();
            return Content;
        }

        public byte[] RotatateImage(float RotateByDegrees)
        {
            imageFactory.Rotate(RotateByDegrees)
                        .Save(outStream);
            var Content = outStream.ToArray();
            return Content;
        }
    }
}
