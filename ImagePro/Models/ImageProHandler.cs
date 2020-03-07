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
    }
}
