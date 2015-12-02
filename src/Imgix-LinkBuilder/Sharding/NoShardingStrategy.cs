using System;

namespace Imgix_LinkBuilder.Sharding
{
    /// <summary>
    /// A sharding strategy that does no sharding. Always returns 0
    /// </summary>
    public class NoShardingStrategy : IShardingStrategy
    {
        /// <summary>
        /// Get the shard id based on the passed in path.
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="shardCount">How many shards are we working with</param>
        /// <returns>Always returns 0</returns>
        public int GetShardId(string path, int shardCount)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new ArgumentException(nameof(path) + " cannot be empty", nameof(path));
            return 0;
        }
    }
}