using System.Globalization;

namespace Imgix_Dotnet.Operations.FaceDetection
{
    /// <summary>
    /// ImgixImage extension methods that set face detection related parameters on the Url.
    /// </summary>
    public static class FaceDetectionExtensions
    {
        /// <summary>
        /// Adds a faceindex parameter
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="index">
        ///     The index of the face to center on.
        ///     1-based index.
        /// </param>
        /// <returns></returns>
        public static ImgixImage FaceIndex(this ImgixImage image, int index)
            => image.AddParameter("faceindex", index.ToString());

        /// <summary>
        /// adds the facepad parameter
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <param name="paddingRatio">
        ///     The ratio of padding for each when fit is set to facearea.
        ///     A positive double
        /// </param>
        /// <returns></returns>
        public static ImgixImage FacePad(this ImgixImage image, double paddingRatio)
            => image.AddParameter("facepad", paddingRatio.ToString(CultureInfo.InvariantCulture));

        /// <summary>
        /// Adds the faces parameter
        /// </summary>
        /// <param name="image">The image to transform</param>
        /// <returns></returns>
        public static ImgixImage Faces(this ImgixImage image)
            => image.AddParameter("faces", "1");
    }
}