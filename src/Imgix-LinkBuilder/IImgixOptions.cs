using System.Collections.Generic;

namespace Imgix_LinkBuilder
{
    /// <summary>
    /// Imgix builder options.
    /// Specific option implementations should implement this interface.
    /// </summary>
    public interface IImgixOptions
    {
        /// <summary>
        /// An enumrarable of imgix sources
        /// </summary>
        IEnumerable<ImgixSource> Sources { get; }
    }
}