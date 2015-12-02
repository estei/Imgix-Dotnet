using System.Collections.Generic;

namespace Imgix_Dotnet.Configuration
{
    /// <summary>
    /// Basic options
    /// </summary>
    public class ImgixOptions : IImgixOptions
    {
        /// <summary>
        /// Initializes an options object with multiple sources
        /// </summary>
        /// <param name="sources"></param>
        public ImgixOptions(IEnumerable<ImgixSource> sources )
        {
            Sources = sources;
        }

        /// <summary>
        /// Initializes an options object with a single source
        /// </summary>
        /// <param name="source"></param>
        public ImgixOptions(ImgixSource source) : this(new List<ImgixSource> {source})
        {
        }
        /// <summary>
        /// An enumrarable of imgix sources
        /// </summary>
        public IEnumerable<ImgixSource> Sources { get; }
    }
}