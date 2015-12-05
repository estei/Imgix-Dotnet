using System.Configuration;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    /// <summary>
    /// A hostname in a source
    /// </summary>
    public class HostElement : ConfigurationElement
    {
        /// <summary>
        /// The hostname for the host
        /// </summary>
        [ConfigurationProperty("hostname", IsRequired = true)]
        public string HostName
        {
            get { return (string)this["hostname"]; }
            set { this["hostname"] = value; }
        }
    }
}