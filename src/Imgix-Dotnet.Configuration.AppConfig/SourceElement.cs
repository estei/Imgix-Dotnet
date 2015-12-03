using System.Configuration;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    public class SourceElement : ConfigurationElement
    {
        private const string HostsCollectionName = "hosts";

        [ConfigurationProperty(HostsCollectionName, IsRequired = true)]
        [ConfigurationCollection(typeof(HostsCollection), AddItemName = "host")]
        public HostsCollection Hosts => this[HostsCollectionName] as HostsCollection;

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("secureUrlToken", IsRequired = false)]
        public string SecureUrlToken
        {
            get { return (string)this["secureUrlToken"]; }
            set { this["secureUrlToken"] = value; }
        }

        [ConfigurationProperty("isHttps", IsRequired = true)]
        public bool IsHttps
        {
            get { return (bool) this["isHttps"]; }
            set { this["isHttps"] = value; }
        }
    }
}