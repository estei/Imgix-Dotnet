using System.Globalization;

namespace Imgix_LinkBuilder.Transforms.PixelDensity
{
    /// <summary>
    /// ImgixImage extension methods that set pixel density related parameters on the Url.
    /// </summary>
    public static class PixelDensityExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Value: less than 8
        /// </param>
        /// <returns></returns>
        public static ImgixImage DPR(this ImgixImage image, double value)
            => image.AddParameter("dpr", value.ToString(CultureInfo.InvariantCulture));
    }
}