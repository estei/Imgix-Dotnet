using System.Configuration;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    public class HostsCollection :ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
            => new HostElement();

        protected override object GetElementKey(ConfigurationElement element)
            => ((HostElement)element).HostName;
    }
}