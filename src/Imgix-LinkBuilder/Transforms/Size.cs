using System.Globalization;

namespace Imgix_LinkBuilder.Transforms.Size
{
    /// <summary>
    /// ImgixImage extension methods that set size related parameters on the Url.
    /// </summary>
    public static class Size
    {
        /// <summary>
        /// Selects a sub-reqion of the image to use for processing
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="dimensions">
        ///     A comma seperated string of integers of the format "x,y,width,height"
        /// </param>
        /// <returns></returns>
        public static ImgixImage Rect(this ImgixImage image, string dimensions)
            => image.AddParameter("rect", dimensions);

        /// <summary>
        /// Selects a sub-reqion of the image to use for processing
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="x">The x position of the top left corner</param>
        /// <param name="y">The x position of the top left corner</param>
        /// <param name="width">The width of the rectangle</param>
        /// <param name="height">The height of the rectangle</param>
        /// <returns></returns>
        public static ImgixImage Rect(this ImgixImage image, int x, int y, int width, int height)
            => image.Rect($"{x},{y},{width},{height}");

        /// <summary>
        /// Sets the output height of the transformed image.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="height">The pixel height</param>
        /// <returns></returns>
        public static ImgixImage Height(this ImgixImage image, int height) => image.Height(height.ToString());

        /// <summary>
        /// Sets the output height of the transformed image as the ratio of the original size.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="ratio">The ratio compared to the original image. Should be between 0,0 and 1.0</param>
        /// <returns></returns>
        public static ImgixImage Height(this ImgixImage image, double ratio) => image.Height(ratio.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        /// Sets the height of the transformed image.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="height">The height value as a string</param>
        /// <returns></returns>
        public static ImgixImage Height(this ImgixImage image, string height) => image.AddParameter("h", height);

        /// <summary>
        /// Sets the output width of the transformed image.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="width">The pixel width</param>
        /// <returns></returns>
        public static ImgixImage Width(this ImgixImage image, int width) => image.Width(width.ToString());

        /// <summary>
        /// Sets the output width of the transformed image as the ratio of the original size.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="ratio">The ratio compared to the original image. Should be between 0,0 and 1.0</param>
        /// <returns></returns>
        public static ImgixImage Width(this ImgixImage image, double ratio) => image.Width(ratio.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        /// Sets the width of the transformed image.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="width">The width value as a string</param>
        /// <returns></returns>
        public static ImgixImage Width(this ImgixImage image, string width) => image.AddParameter("w", width);

        /// <summary>
        /// Controls how the image is aligned when fit has been set to crop
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="cropMode">
        ///     The crop mode value. Can be a comma seperated list.
        ///     Values: top, bottom, left, right, faces, entropy
        /// </param>
        /// <returns></returns>
        public static ImgixImage Crop(this ImgixImage image, string cropMode) => image.AddParameter("crop", cropMode);

        /// <summary>
        /// How is the output image fit into the target dimensions.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="fit">
        ///     The fit mode
        ///     Values: clamp, clip, crop, facearea, fill, max, min, scale
        /// </param>
        /// <returns></returns>
        public static ImgixImage Fit(this ImgixImage image, string fit) => image.AddParameter("fit", fit);
    }
}