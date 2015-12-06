using System.Configuration;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    /// <summary>
    /// Get Imgix configuration from app config
    /// </summary>
    public static class ImgixAppConfig
    {
        /// <summary>
        /// Gets the configuration from App config
        /// </summary>
        /// <returns></returns>
        public static ImgixSection GetImgixSection()
            => ConfigurationManager.GetSection(ImgixSection.SectionName) as ImgixSection;

        /// <summary>
        /// Gets the configuration from App config as ImgixOptions object
        /// </summary>
        /// <returns></returns>
        public static IImgixOptions GetOptions()
            => new ImgixOptions(GetImgixSection().Sources.ToImgixSourceEnumerable());
    }
}