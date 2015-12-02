namespace Imgix_Dotnet.Transforms.Padding
{
    /// <summary>
    /// ImgixImage extension methods that sets padding related parameters on the Url.
    /// </summary>
    public static class PaddingExtensions
    {
        /// <summary>
        /// Adds padding to the image.
        /// If the image does not have any size parameters the padding will extend the picture.
        /// If there are size parameters, the image will be shrunk to fit
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The thickness of the padding.
        /// </param>
        /// <returns></returns>
        public static ImgixImage Padding(this ImgixImage image, int value)
            => image.AddParameter("pad", value);
    }
}