using System.Configuration;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    public class HostElement : ConfigurationElement
    {
        [ConfigurationProperty("hostname", IsRequired = true)]
        public string HostName
        {
            get { return (string)this["hostname"]; }
            set { this["hostname"] = value; }
        }
    }
}