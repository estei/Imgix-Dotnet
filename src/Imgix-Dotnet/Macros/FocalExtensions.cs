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
                cropRectangle = cropRectangle.ResizeToFitWithin(imageRectangle);
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


    }
}