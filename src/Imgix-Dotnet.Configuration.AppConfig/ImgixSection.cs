using System.Configuration;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    /// <summary>
    /// A configuration section for Imgix
    /// </summary>
    public class ImgixSection : ConfigurationSection
    {
        /// <summary>
        /// The name of the section
        /// </summary>
        public const string SectionName = "imgix";
        private const string SourcesCollectionName = "sources";

        /// <summary>
        /// The sources defined for Imgix
        /// </summary>
        [ConfigurationProperty(SourcesCollectionName, IsRequired = true)]
        [ConfigurationCollection(typeof(SourcesCollection), AddItemName = "source")]
        public SourcesCollection Sources => this[SourcesCollectionName] as SourcesCollection;
    }
}