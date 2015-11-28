namespace Imgix_LinkBuilder.Transforms
{
    /// <summary>
    /// Extensions for extracting color palettes out of images
    /// </summary>
    public static class PaletteExtensions
    {
        /// <summary>
        /// The format you want the palette in.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: css or json
        /// </param>
        /// <returns></returns>
        public static ImgixImage Palette(this ImgixImage image, string value)
            => image.AddParameter("palette", value);

        /// <summary>
        /// The prefix to use with css classes generated when palette set to css
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The prefix value
        ///     Ex. [prefix]-fg-1
        /// </param>
        /// <returns></returns>
        public static ImgixImage CSSPrefix(this ImgixImage image, string value)
            => image.AddParameter("prefix", value);

        /// <summary>
        /// The number of colors that should be returned when extracting the palette
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: 0-16
        /// </param>
        /// <returns></returns>
        public static ImgixImage Colors(this ImgixImage image, int value)
            => image.AddParameter("colors", value.ToString());
    }
}