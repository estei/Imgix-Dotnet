namespace Imgix_LinkBuilder
{
    /// <summary>
    /// The strategy used for sharding hosts.
    /// </summary>
    public enum ShardingStrategy
    {
        /// <summary>
        /// There is no sharding.
        /// If multiple hosts are defined the first one is taken.
        /// </summary>
        None,
        /// <summary>
        /// Chooses a host based on a hash generated from the path.
        /// This ensures that the same host is always chosen for the same path.
        /// </summary>
        Hash,
        /// <summary>
        /// Cycle the hosts.
        /// This has the weakness that the same path can link to different hosts, effectively busting caching.
        /// </summary>
        Cycle
    }
}