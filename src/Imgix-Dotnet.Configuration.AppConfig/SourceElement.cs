using System;
using System.Configuration;
using System.Linq;
using Imgix_Dotnet.Sharding;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    /// <summary>
    /// A source
    /// </summary>
    public class SourceElement : ConfigurationElement
    {
        private const string HostsCollectionName = "hosts";

        /// <summary>
        /// The hosts defined in the source
        /// </summary>
        [ConfigurationProperty(HostsCollectionName, IsRequired = true)]
        [ConfigurationCollection(typeof(HostsCollection), AddItemName = "host")]
        public HostsCollection Hosts => this[HostsCollectionName] as HostsCollection;

        /// <summary>
        /// The name of the source
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// The secure url token to sign urls with
        /// </summary>
        [ConfigurationProperty("secureUrlToken", IsRequired = false)]
        public string SecureUrlToken
        {
            get { return (string)this["secureUrlToken"]; }
            set { this["secureUrlToken"] = value; }
        }

        /// <summary>
        /// Is the source https
        /// </summary>
        [ConfigurationProperty("isHttps", IsRequired = true)]
        public bool IsHttps
        {
            get { return (bool)this["isHttps"]; }
            set { this["isHttps"] = value; }
        }

        /// <summary>
        /// The sharding strategy for the source
        /// </summary>
        [ConfigurationProperty("shardingStrategy", IsRequired = true)]
        public ShardingStrategyElement ShardingStrategy
            => (ShardingStrategyElement)base["shardingStrategy"];

        /// <summary>
        /// Return an ImgIxSource based on this object
        /// </summary>
        /// <returns></returns>
        public ImgixSource ToImgixSource()
            => new ImgixSource(
                Name,
                SecureUrlToken ?? "",
                Hosts.Select(host => host.HostName).ToArray(),
                IsHttps,
                new HashShardingStrategy()
            );
    }
}