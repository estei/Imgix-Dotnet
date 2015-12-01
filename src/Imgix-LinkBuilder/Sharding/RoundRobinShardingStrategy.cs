using System;

namespace Imgix_LinkBuilder.Sharding
{
    /// <summary>
    /// Cycles the
    /// </summary>
    public class RoundRobinShardingStrategy : IShardingStrategy
    {
        private int _nextShardId;

        /// <summary>
        /// Initializes a new RoundRobinShardingStrategy object.
        /// Since this contains a counter we should never copy it. Create a new every time.
        /// </summary>
        public RoundRobinShardingStrategy()
        {
            _nextShardId = 0;
        }

        /// <summary>
        /// Returns the next shard id in a round robin fashion
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="shardCount">How many shards are we working with</param>
        /// <returns></returns>
        public int GetShardId(string path, int shardCount)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new ArgumentException(nameof(path)+" cannot be empty", nameof(path));
            //no need to calculate anything if there is only one shard
            if (shardCount == 1)
            {
                return 0;
            }
            var previousShardId = _nextShardId;
            _nextShardId = (_nextShardId + 1) % shardCount;
            return previousShardId <= shardCount ? previousShardId : previousShardId % shardCount;
        }
    }
}