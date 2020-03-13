using ImagePro.Models;
using ImageProcessor;
using ImageProcessor.Processors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ImagePro.Service
{
    public class ImageProHandler : IImageProHandler
    {
        //object of the ImageFactory class
        public ImageFactory imageFactory { get; set; }
        public string ImageStream { get; set; } = "Initial";
        //variables to store image in memory
        public MemoryStream inStream { get; set; }
        public MemoryStream outStream { get; set; }

        public ImageProHandler()
        {
            imageFactory = new ImageFactory(preserveExifData: true);
            inStream = new MemoryStream();
            outStream = new MemoryStream();
        }

        public ImageResult MultipleOperation(MultiOperation inputs)
        {
            var result = new ImageResult
            {
                Message = OpMessage.Success
            };
            var param = inputs.MultiOperationParam;
            var flipOps = param.FlipParam;
            var gsOps = param.GreyScaleParam;
            var resizeOps = param.ResizeParam;
            var rotateOps = param.RotateParam;
            var thumbnailOps = param.ThumbnailParam;

            var allOps = flipOps.Count() + gsOps.Count() + resizeOps.Count() + rotateOps.Count() + thumbnailOps.Count();

            if (allOps != param.MultiOperationSequence.Count() || param.MultiOperationSequence.Count() == 0)
            {
                result.Message = OpMessage.InvalidInputParameter;
                return result;
            }
            try
            {
                param.MultiOperationSequence.ForEach(operation => {
                    switch (operation)
                    {
                        case Operations.FLIP:
                            var flipParam = flipOps[0];
                            flipOps.Remove(flipParam);
                            var fp = new FlipImage
                            {
                                Param = flipParam,
                            };
                            FlipImage(fp);
                            break;
                        case Operations.ROTATE:
                            var rotateParam = rotateOps[0];
                            rotateOps.Remove(rotateParam);
                            var rop = new RotateImage
                            {
                                Param = rotateParam,
                            };
                            RotateImage(rop);
                            break;
                        case Operations.RESIZE:
                            var resizeParam = resizeOps[0];
                            resizeOps.Remove(resizeParam);
                            var rep = new ResizeImage
                            {
                                Param = resizeParam,
                            };
                            ResizeImage(rep);
                            break;
                        case Operations.GRAYSCALE:
                            var gsParam = gsOps[0];
                            gsOps.Remove(gsParam);
                            GrayScaleImage();
                            break;
                        case Operations.THUMBNAIL:
                            var tp = thumbnailOps[0];
                            thumbnailOps.Remove(tp);
                            ThumbnailImage();
                            break;
                        default:
                            throw new Exception();
                    }
                    imageFactory.Load(outStream);
                });
            }
            catch (Exception ex)
            {
                result.Message = OpMessage.InvalidOperation;
                return result;
            }
            result.Result = outStream.ToArray();
            return result;
        }

        /// <summary>
        /// Method to laod Image in memory
        /// </summary>
        /// <param name="ImageStream"></param>
        public void LoadImage(String ImageStream)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(ImageStream);
                inStream = new MemoryStream(bytes);
                imageFactory.Load(inStream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ImageResult FlipImage(FlipImage flipParam)
        {
            var result = new ImageResult
            {
                Message = OpMessage.Success
            };
            try
            {
                if (flipParam.Param.FlipHorizontally && flipParam.Param.FlipVertically)
                {
                    imageFactory.Flip(false, true).Save(outStream);
                }
                else if (!flipParam.Param.FlipHorizontally)
                {
                    imageFactory.Flip(true, false).Save(outStream);
                }
                else
                {
                    imageFactory.Flip(true, false).Save(outStream);
                    imageFactory.Flip(false, true).Save(outStream);
                }
            }
            catch (Exception ex)
            {
                result.Message = OpMessage.InvalidInputParameter;
                return result;
            }

            result.Result = outStream.ToArray();
            return result;
        }

        public ImageResult RotateImage(RotateImage rotate)
        {
            var result = new ImageResult
            {
                Message = OpMessage.Success
            };
            try
            {
                if (rotate.Param.RotateLeft)
                {
                    imageFactory.Rotate(270).Save(outStream);
                }
                if (rotate.Param.RotateRight)
                {
                    imageFactory.Rotate(90).Save(outStream);
                }
                if (rotate.Param.RotateByDegrees != 0)
                {
                    imageFactory.Rotate(rotate.Param.RotateByDegrees % 360).Save(outStream);
                }
            }
            catch (Exception ex)
            {
                result.Message = OpMessage.InvalidInputParameter;
                return result;
            }
            result.Result = outStream.ToArray();
            return result;

        }

        public ImageResult ResizeImage(ResizeImage resizeParam)
        {
            var result = new ImageResult
            {
                Message = OpMessage.Success
            };
            try
            {
                imageFactory.Resize(new Size(resizeParam.Param.Heigth, resizeParam.Param.Width)).Save(outStream);
            }
            catch (Exception ex)
            {
                result.Message = OpMessage.InvalidInputParameter;
                return result;
            }
            result.Result = outStream.ToArray();
            return result;
        }

        public ImageResult ThumbnailImage()
        {
            var result = new ImageResult
            {
                Message = OpMessage.Success
            };
            try
            {
                imageFactory.Resize(new Size(200, 200)).Save(outStream);
            }
            catch (Exception ex)
            {
                result.Message = OpMessage.InvalidInputParameter;
                return result;
            }
            result.Result = outStream.ToArray();
            return result;
        }

        public ImageResult GrayScaleImage()
        {
            var result = new ImageResult
            {
                Message = OpMessage.Success
            };
            try
            {
                Filter filer = new Filter();
                filer.DynamicParameter = ImageProcessor.Imaging.Filters.Photo.MatrixFilters.GreyScale;
                imageFactory.Filter(filer.DynamicParameter).Save(outStream);


                //imageFactory.GrayScaleImage(new Size(200, 200)).Save(outStream);
            }
            catch (Exception ex)
            {
                result.Message = OpMessage.InvalidInputParameter;
                return result;
            }
            result.Result = outStream.ToArray();
            return result;
        }


    }
}
