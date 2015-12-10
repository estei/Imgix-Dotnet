namespace Imgix_Dotnet.Operations.Border
{
    /// <summary>
    /// ImgixImage extension methods that sets border related parameters on the Url.
    /// </summary>
    public static class BorderExtensions
    {
        /// <summary>
        /// Sets the border around the image.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     A String describing the border.
        ///     Value: size,color
        ///     Size: An integer value
        ///     Color: An RGB or ARGB value
        /// </param>
        /// <returns></returns>
        public static ImgixImage Border(this ImgixImage image, string value)
            => image.AddParameter("border", value);
    }
}