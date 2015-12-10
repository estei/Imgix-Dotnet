namespace Imgix_Dotnet.Operations.PDF
{
    /// <summary>
    /// ImgixImage extension methods that sets PDF related parameters on the Url.
    /// </summary>
    public static class PDFExtensions
    {
        /// <summary>
        /// The page from a PDF file to create an image from
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Default: 1
        /// </param>
        /// <returns></returns>
        public static ImgixImage Page(this ImgixImage image, int value)
            => image.AddParameter("page", value);
    }
}