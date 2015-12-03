using System.Configuration;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    public class ImgixSection : ConfigurationSection
    {
        public const string SectionName = "imgix";
        private const string SourcesCollectionName = "sources";

        [ConfigurationProperty(SourcesCollectionName, IsRequired = true)]
        [ConfigurationCollection(typeof(SourcesCollection), AddItemName = "source")]
        public SourcesCollection Sources => this[SourcesCollectionName] as SourcesCollection;
    }
}