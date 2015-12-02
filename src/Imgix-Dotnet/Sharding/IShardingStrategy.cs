namespace Imgix_Dotnet.Sharding
{
    /// <summary>
    /// A strategy for sharding of hosts.
    /// </summary>
    public interface IShardingStrategy
    {
        /// <summary>
        /// Get the shard id based on the passed in path.
        /// </summary>
        /// <param name="path">
        ///     The path
        ///     Value cannot be empty
        /// </param>
        /// <param name="shardCount">
        ///     How many shards are we working with
        ///     Should be a postive integer
        ///     If set to 1 this method should always return 0
        /// </param>
        /// <returns></returns>
        int GetShardId(string path, int shardCount);
    }
}