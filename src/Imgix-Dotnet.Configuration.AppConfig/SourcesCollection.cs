using System.Configuration;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    public class SourcesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
            => new SourceElement();

        protected override object GetElementKey(ConfigurationElement element)
            => ((SourceElement) element).Name;
    }
}