namespace Imgix_LinkBuilder.Transforms.Trim
{
    /// <summary>
    /// ImgixImage extension methods that sets trim related parameters on the Url.
    /// </summary>
    public static class TrimExtensions
    {
        /// <summary>
        /// Adds the trim parameter to the image url.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        /// The trim operation to perform
        /// Values: auto or color
        /// </param>
        /// <returns></returns>
        public static ImgixImage Trim(this ImgixImage image, string value)
            => image.AddParameter("trim", value);

        /// <summary>
        /// Adds the timecolor parameter to the image url
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     A three or six char hex color string
        /// </param>
        /// <returns></returns>
        public static ImgixImage TrimColor(this ImgixImage image, string value)
            => image.AddParameter("trimcolor", value);

        /// <summary>
        /// The difference threshhold used when trimming a border.
        /// Only valid when trim is set to auto
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     A lower value makes the trimming more aggressive
        ///     Default: 11
        /// </param>
        /// <returns></returns>
        public static ImgixImage TrimMeanDifference(this ImgixImage image, int value)
            => image.AddParameter("trimmd", value.ToString());

        /// <summary>
        /// Defines the standard deviation among pixels in a border.
        /// Only valid when trim is set to auto
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The standard deviation
        ///     Default: 10
        /// </param>
        /// <returns></returns>
        public static ImgixImage TrimStandardDeviation(this ImgixImage image, int value)
            => image.AddParameter("trimsd", value.ToString());


        /// <summary>
        /// DEfines the tolerance when trim has been set to color.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The tolerance
        ///     Default: 0
        /// </param>
        /// <returns></returns>
        public static ImgixImage TrimTolerance(this ImgixImage image, int value)
            => image.AddParameter("trimtol", value.ToString());
    }
}