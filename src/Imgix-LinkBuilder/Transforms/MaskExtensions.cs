namespace Imgix_LinkBuilder.Transforms.Mask
{
    /// <summary>
    /// ImgixImage extension methods that set mask related parameters on the Url.
    /// </summary>
    public static class MaskExtensions
    {
        /// <summary>
        /// Adds a mask parameter with the value ellipse
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static ImgixImage EllipseMask(this ImgixImage image) => image.AddParameter("mask", "ellipse");

        /// <summary>
        /// Adds a mask parameter with the supplied string as value
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">The value of the mask parameter</param>
        /// <returns></returns>
        public static ImgixImage Mask(this ImgixImage image, string value) => image.AddParameter("mask", value);
    }
}