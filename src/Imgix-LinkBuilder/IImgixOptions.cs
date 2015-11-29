namespace Imgix_LinkBuilder
{
    /// <summary>
    /// Imgix builder options.
    /// Specific option implementations should implement this interface.
    /// </summary>
    public interface IImgixOptions
    {
        /// <summary>
        /// Should return the source name in imgix.
        /// </summary>
        string SourceName { get; }

        /// <summary>
        /// Should the builder use https
        /// </summary>
        bool UseHttps { get; }

        /// <summary>
        /// The token used for signing urls
        /// </summary>
        string SecureUrlToken { get; }
    }
}