namespace Imgix_Dotnet.Transforms.Noise
{
    /// <summary>
    /// ImgixImage extension methods that sets noise related parameters on the Url.
    /// </summary>
    public static class NoiseExtensions
    {
        /// <summary>
        /// Sets the threshold for noise removal
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values -100 - 100
        ///     Default: 20
        /// </param>
        /// <returns></returns>
        public static ImgixImage NoiseReductionBlur(this ImgixImage image, int value)
            => image.AddParameter("nr", value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="value">
        ///     Values -100 - 100
        ///     Default: 20
        /// </param>
        /// <returns></returns>
        public static ImgixImage NoiseReductionSharpen(this ImgixImage image, int value)
            => image.AddParameter("nrs", value);
    }
}