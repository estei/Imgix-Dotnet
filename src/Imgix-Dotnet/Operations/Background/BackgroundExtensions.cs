namespace Imgix_Dotnet.Operations.Background
{
    /// <summary>
    /// ImgixImage extension methods that sets background related parameters on the Url.
    /// </summary>
    public static class BackgroundExtensions
    {
        /// <summary>
        /// Adds a background color to the image if there is transparency in it
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     3, 4, 6 and 8 character color values
        /// </param>
        /// <returns></returns>
        public static ImgixImage BackgroundColor(this ImgixImage image, string value)
            => image.AddParameter("bg", value);
    }
}