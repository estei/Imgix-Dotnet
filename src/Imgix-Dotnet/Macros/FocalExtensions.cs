using System;
using Imgix_Dotnet.Operations.Size;

namespace Imgix_Dotnet.Macros
{
    /// <summary>
    /// Macros that work around focal points instead of the top left corner
    /// </summary>
    public static class FocalExtensions
    {
        /// <summary>
        /// Crops the image around a focal point.
        /// Will try and center on the focal point if possible, but if the crop falls outside the area of the image it will adjust.
        /// Keeps the aspect of the crop.
        /// </summary>
        /// <param name="image">The image to run the macro on</param>
        /// <param name="x">The horizontal position of the focal point</param>
        /// <param name="y">The y position of the focal point</param>
        /// <param name="width">The width of the area to crop</param>
        /// <param name="height">The height of the area to crop</param>
        /// <param name="sourceWidth">The original image width</param>
        /// <param name="sourceHeight">The original image height</param>
        /// <returns></returns>
        public static ImgixImage FocalCrop(this ImgixImage image, int x, int y, int width, int height, int sourceWidth,
            int sourceHeight)
        {
            var cropRectangle = new Rectangle(width, height);
            var imageRectangle = new Rectangle(sourceWidth, sourceHeight);
            if (!imageRectangle.CanHold(cropRectangle))
            {
                cropRectangle = cropRectangle.EnsureFit(imageRectangle);
            }
            var cropTopLeftCorner = new Point(x-cropRectangle.Width/2, y-cropRectangle.Height/2);
            var cropBottomRightCorner = new Point(cropTopLeftCorner.X + cropRectangle.Width, cropTopLeftCorner.Y + cropRectangle.Height);
            //Adjust x position
            if (cropTopLeftCorner.X < 0)
            {
                cropTopLeftCorner = cropTopLeftCorner.SetX(0);
            }
            else if (cropBottomRightCorner.X > sourceWidth)
            {
                cropTopLeftCorner = cropTopLeftCorner.SetX(sourceWidth - cropRectangle.Width);
            }
            //Adjust y position
            if (cropTopLeftCorner.Y < 0)
            {
                cropTopLeftCorner = cropTopLeftCorner.SetY(0);
            }
            else if (cropBottomRightCorner.Y > sourceHeight)
            {
                cropTopLeftCorner = cropTopLeftCorner.SetY(sourceHeight - cropRectangle.Height);
            }
            return image.Rect(cropTopLeftCorner.X, cropTopLeftCorner.Y, cropRectangle.Width, cropRectangle.Height);
        }

        /// <summary>
        /// Crops the image around a focal point.
        /// Will try and center on the focal point if possible, but if the crop falls outside the area of the image it will adjust.
        /// Keeps the aspect of the crop.
        /// </summary>
        /// <param name="image">The image to run the macro on</param>
        /// <param name="x">
        ///     The horizontal position of the focal point.
        ///     Interpreted as a percentage of the image width from the left.
        ///     Values 0.0 to 1.0
        /// </param>
        /// <param name="y">
        ///     The y position of the focal point.
        ///     Interpreted as a percentage of the image height from the top side.
        ///     Values 0.0 to 1.0
        /// </param>
        /// <param name="width">The width of the area to crop</param>
        /// <param name="height">The height of the area to crop</param>
        /// <param name="sourceWidth">The original image width</param>
        /// <param name="sourceHeight">The original image height</param>
        /// <exception cref="ArgumentOutOfRangeException">If either x or y is outside the 0.0 to 1.0 range</exception>
        /// <returns></returns>
        public static ImgixImage FocalCrop(this ImgixImage image, double x, double y, int width,
            int height, int sourceWidth, int sourceHeight)
        {
            if (x < 0.0 && x > 1.0) throw new ArgumentOutOfRangeException(nameof(x));
            if (y < 0.0 && y > 1.0) throw new ArgumentOutOfRangeException(nameof(y));
            var focalPoint = new Point(Convert.ToInt32(sourceWidth * x), Convert.ToInt32(sourceHeight * y));
            return image.FocalCrop(focalPoint.X, focalPoint.Y, width, height, sourceWidth, sourceHeight);
        }

        /// <summary>
        ///     Resizes the image around a focal point
        ///     Crops the image to the aspect ratio with the focal point as close to center as possible.
        ///     Will not stretch the image to the width and height since this will just be a bigger picture with the same details.
        /// </summary>
        /// <param name="image">The image to run the macro on</param>
        /// <param name="x">
        ///     The horizontal position of the focal point.
        ///     Interpreted as a percentage of the image width from the left.
        ///     Values 0.0 to 1.0
        /// </param>
        /// <param name="y">
        ///     The y position of the focal point.
        ///     Interpreted as a percentage of the image height from the top side.
        ///     Values 0.0 to 1.0
        /// </param>
        /// <param name="width">The width of the resulting image</param>
        /// <param name="height">The height of the resulting image</param>
        /// <param name="sourceWidth">The original image width</param>
        /// <param name="sourceHeight">The original image height</param>
        /// <returns></returns>
        public static ImgixImage FocalResize(this ImgixImage image, double x, double y, int width,
            int height, int sourceWidth, int sourceHeight)
        {
            var resizeRectangle = new Rectangle(width, height);
            var imageRectangle = new Rectangle(sourceWidth, sourceHeight);
            var cropRectangle = resizeRectangle.Match(imageRectangle);
            var croppedImage = image.FocalCrop(x, y, cropRectangle.Width, cropRectangle.Height, sourceWidth,
                sourceHeight);
            return !imageRectangle.CanHold(resizeRectangle) ? croppedImage : croppedImage.Width(width).Height(height);
        }

        /// <summary>
        ///     Resizes the image around a focal point
        ///     Crops the image to the aspect ratio with the focal point as close to center as possible.
        ///     Will not stretch the image to the width and height since this will just be a bigger picture with the same details.
        /// </summary>
        /// <param name="image">The image to run the macro on</param>
        /// <param name="x">The horizontal position of the focal point</param>
        /// <param name="y">The y position of the focal point</param>
        /// <param name="width">The width of the resulting image</param>
        /// <param name="height">The height of the resulting image</param>
        /// <param name="sourceWidth">The original image width</param>
        /// <param name="sourceHeight">The original image height</param>
        /// <returns></returns>
        public static ImgixImage FocalResize(this ImgixImage image, int x, int y, int width,
            int height, int sourceWidth, int sourceHeight)
        {
            var resizeRectangle = new Rectangle(width, height);
            var imageRectangle = new Rectangle(sourceWidth, sourceHeight);
            var cropRectangle = resizeRectangle.Match(imageRectangle);
            var croppedImage = image.FocalCrop(x, y, cropRectangle.Width, cropRectangle.Height, sourceWidth,
                sourceHeight);
            return !imageRectangle.CanHold(resizeRectangle) ? croppedImage : croppedImage.Width(width).Height(height);
        }
    }
}