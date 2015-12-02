namespace Imgix_Dotnet.Transforms.Format
{
    /// <summary>
    /// ImgixImage extension methods that sets format related parameters on the Url.
    /// </summary>
    public static class FormatExtensions
    {
        /// <summary>
        /// Adds ch parameter opting in to using client hints.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     A comma seperated list of hints
        ///     Values: Width and DPR are currently supported
        /// </param>
        /// <returns></returns>
        public static ImgixImage ClientHints(this ImgixImage image, string value)
            => image.AddParameter("ch", value);

        /// <summary>
        /// Chroma subsampling for JPEG and Progressive JPEG
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: 420, 422, and 444
        ///     Default: 420
        /// </param>
        /// <returns></returns>
        public static ImgixImage ChromaSubsampling(this ImgixImage image, int value)
            => image.AddParameter("chromasub", value);


        /// <summary>
        /// Adds color quantization to the image, limiting the amount of colors in the image.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: 2-256
        /// </param>
        /// <returns></returns>
        public static ImgixImage ColorQuantization(this ImgixImage image, int value)
            => image.AddParameter("colorquant", value);

        /// <summary>
        /// When used in an a tag forces download with the specified name
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The download name of the image
        /// </param>
        /// <returns></returns>
        public static ImgixImage Download(this ImgixImage image, string value)
            => image.AddParameter("dl", value);

        /// <summary>
        /// Sets the DPI value in the Exif header
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The DPI value
        /// </param>
        /// <returns></returns>
        public static ImgixImage DPI(this ImgixImage image, int value)
            => image.AddParameter("dpi", value);

        /// <summary>
        /// Sets the output format of the image.
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     The format name
        ///     Values: gif, jp2, jpg, json, jxr, pjpg, mp4, png, png8, png32, webp
        /// </param>
        /// <returns></returns>
        public static ImgixImage OutputFormat(this ImgixImage image, string value)
            => image.AddParameter("fm", value);

        /// <summary>
        /// Should the returned image be lossless
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: 0, 1, true, false
        /// </param>
        /// <returns></returns>
        public static ImgixImage Lossless(this ImgixImage image, string value)
            => image.AddParameter("lossless", value);

        /// <summary>
        /// SEts the oputput quality of the image
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values: 0-100
        ///     Default: 75
        /// </param>
        /// <returns></returns>
        public static ImgixImage Quality(this ImgixImage image, int value)
            => image.AddParameter("q", value);
    }
}