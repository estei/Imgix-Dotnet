using System.Configuration;
using Imgix_Dotnet.Sharding;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    /// <summary>
    /// A shardingstrategy
    /// </summary>
    public class ShardingStrategyElement : ConfigurationElement
    {
        /// <summary>
        /// The name of the sharding strategy
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
            => (string)this["name"];

        /// <summary>
        /// Returns a sharding strategy configured as defined in the configuration.
        /// </summary>
        /// <returns></returns>
        public IShardingStrategy ToShardingStrategy()
            => ShardingFactory.GetStrategy(Name);
    }
}