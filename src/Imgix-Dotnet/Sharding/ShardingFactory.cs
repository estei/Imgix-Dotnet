using System;

namespace Imgix_Dotnet.Sharding
{
    /// <summary>
    /// A static sharding strategy factory
    /// </summary>
    public static class ShardingFactory
    {
        /// <summary>
        /// Creates and returns a new sharding strategy from a name.
        /// </summary>
        /// <param name="name">
        ///     The name of the strategy.
        ///     Values: Hash, None, RoundRobin
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If no name is given</exception>
        /// <exception cref="Exception">If no strategy with the name given exists</exception>
        public static IShardingStrategy GetStrategy(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("You must give a name for the strategy", nameof(name));
            switch (name.ToLower())
            {
                case "hash":
                    return new HashShardingStrategy();
                case "none":
                    return new NoShardingStrategy();
                case "roundrobin":
                    return new RoundRobinShardingStrategy();
                default:
                    throw new Exception($"No default sharding strategy named {name}");
            }
        }
    }
}