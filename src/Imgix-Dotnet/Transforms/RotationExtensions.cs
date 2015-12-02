namespace Imgix_Dotnet.Transforms.Rotation
{
    /// <summary>
    /// ImgixImage extension methods that set rotation related parameters on the Url.
    /// </summary>
    public static class RotationExtensions
    {
        /// <summary>
        /// Flips the image horizontally, vertically or both
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The direction to flip
        ///     Values: h, v or hv
        /// </param>
        /// <returns></returns>
        public static ImgixImage Flip(this ImgixImage image, string value)
            => image.AddParameter("flip", value);

        /// <summary>
        /// Changes the Exif orientation
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The orientation value.
        ///     1-8 or 90, 180, 270
        /// </param>
        /// <returns></returns>
        public static ImgixImage Orientation(this ImgixImage image, string value)
            => image.AddParameter("or", value);

        /// <summary>
        /// Rotates the image from 0-359 degrees
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">The rotation in degrees</param>
        /// <returns></returns>
        public static ImgixImage Rotation(this ImgixImage image, int value)
            => image.AddParameter("rot", value);
    }
}