using System;

namespace Imgix_Dotnet.Sharding
{
    /// <summary>
    /// A hashing shard strategy. The same path will always be sent to the same shard.
    /// </summary>
    public class HashShardingStrategy : IShardingStrategy
    {
        /// <summary>
        /// Get the shard id based on the passed in path.
        /// This is done through hashing the path.
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="shardCount">How many shards are we working with</param>
        /// <returns>An integer between 0 and shardCount</returns>
        public int GetShardId(string path, int shardCount)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new ArgumentException(nameof(path) + " cannot be empty", nameof(path));
            //no need to calculate anything if there is only one shard
            if (shardCount == 1)
            {
                return 0;
            }
            return Math.Abs(path.GetHashCode()) % shardCount;
        }
    }
}