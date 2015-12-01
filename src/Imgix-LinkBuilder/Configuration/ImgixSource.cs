using System;
using Imgix_LinkBuilder.Sharding;

namespace Imgix_LinkBuilder.Configuration
{
    /// <summary>
    /// An imgix source
    /// </summary>
    public class ImgixSource
    {
        private readonly string[] _hosts;
        private readonly IShardingStrategy _shardingStrategy;
        private readonly int _hostsCount;
        private readonly bool _isHttps;
        private readonly string _secureUrlToken;

        /// <summary>
        /// Initializes a new https ImgixSource object with a single host.
        /// </summary>
        /// <param name="name">The name of the source</param>
        /// <param name="host">
        ///     The host to use for images.
        ///     If only single word with no dots it will be assumed that it is an imgix source identifier and add .imgix.net
        /// </param>
        public ImgixSource(string name, string host) : this(name, "", host)
        {
        }

        /// <summary>
        /// Initializes a new https ImgixSource object with a single host.
        /// </summary>
        /// <param name="name">The name of the source</param>
        /// <param name="host">
        ///     The host to use for images.
        ///     If only single word with no dots it will be assumed that it is an imgix source identifier and add .imgix.net
        /// </param>
        /// <param name="isHttps">Should urls use https</param>
        public ImgixSource(string name, string host, bool isHttps) : this(name, "", host, isHttps)
        {
        }

        /// <summary>
        /// Initializes a new https ImgixSource object with a single host.
        /// </summary>
        /// <param name="name">The name of the source</param>
        /// <param name="secureUrlToken">The secure url token for the source used to sign urls</param>
        /// <param name="host">
        ///     The host to use for images.
        ///     If only single word with no dots it will be assumed that it is an imgix source identifier and add .imgix.net
        /// </param>
        public ImgixSource(string name, string secureUrlToken, string host) : this(name, secureUrlToken, host, true)
        {
        }

        /// <summary>
        /// Initializes a new https ImgixSource object with a single host.
        /// </summary>
        /// <param name="name">The name of the source</param>
        /// <param name="secureUrlToken">The secure url token for the source used to sign urls</param>
        /// <param name="host">
        ///     The host to use for images.
        ///     If only single word with no dots it will be assumed that it is an imgix source identifier and add .imgix.net
        /// </param>
        /// <param name="isHttps">Should urls use https</param>
        public ImgixSource(string name, string secureUrlToken, string host, bool isHttps) : this(name, secureUrlToken, new[] { host }, isHttps, new NoShardingStrategy())
        {
        }

        /// <summary>
        /// Initializes a new https ImgixSource object with multiple hosts.
        /// </summary>
        /// <param name="name">The name of the source</param>
        /// <param name="hosts">
        ///     An array of hosts.
        ///     If a host is only single word with no dots it will be assumed that it is an imgix source identifier and add .imgix.net
        /// </param>
        /// <param name="isHttps">Should urls use https</param>
        /// <param name="shardingStrategy">
        ///     What strategy should be used for sharding hosts.
        ///     Note: Sharding can lead to problems
        ///     http://perf.fail/post/96104709544/zealous-sharding-hurts-etsy-performance
        ///     and
        ///     https://docs.google.com/presentation/d/1r7QXGYOLCh4fcUq0jDdDwKJWNqWK1o4xMtYpKZCJYjM/present?slide=id.g518e3c87f_0_300
        ///     Recommended to only use two shards.
        /// </param>
        public ImgixSource(string name, string[] hosts, bool isHttps, IShardingStrategy shardingStrategy)
            : this(name, "", hosts, isHttps, shardingStrategy)
        {
        }

        /// <summary>
        /// Initializes a new https ImgixSource object with multiple hosts.
        /// </summary>
        /// <param name="name">The name of the source</param>
        /// <param name="secureUrlToken">The secure url token for the source used to sign urls</param>
        /// <param name="hosts">
        ///     An array of hosts.
        ///     If a host is only single word with no dots it will be assumed that it is an imgix source identifier and add .imgix.net
        /// </param>
        /// <param name="isHttps">Should urls use https</param>
        /// <param name="shardingStrategy">
        ///     What strategy should be used for sharding hosts.
        ///     Note: Sharding can lead to problems
        ///     http://perf.fail/post/96104709544/zealous-sharding-hurts-etsy-performance
        ///     and
        ///     https://docs.google.com/presentation/d/1r7QXGYOLCh4fcUq0jDdDwKJWNqWK1o4xMtYpKZCJYjM/present?slide=id.g518e3c87f_0_300
        ///     Recommended to only use two shards.
        /// </param>
        public ImgixSource(string name, string secureUrlToken, string[] hosts, bool isHttps, IShardingStrategy shardingStrategy)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
            if (secureUrlToken == null) throw new ArgumentNullException(nameof(secureUrlToken)+" cannot be null", nameof(secureUrlToken));
            if (hosts.Length == 0) throw new ArgumentException("Must define atleast one host", nameof(hosts));
            if (shardingStrategy == null) throw new ArgumentNullException(nameof(shardingStrategy));

            Name = name;
            _secureUrlToken = secureUrlToken;
            _isHttps = isHttps;
            _hosts = SanitizeHosts(hosts);
            _shardingStrategy = shardingStrategy;
            _hostsCount = _hosts.Length;
        }

        /// <summary>
        /// The name of the source
        /// </summary>
        public string Name { get; }

        private string Scheme => _isHttps ? "https" : "http";

        /// <summary>
        /// Gets a url for a given path. If sharding is enabled a shard is selected based on the chosen strategy
        /// </summary>
        /// <param name="path">The path to the image</param>
        /// <returns></returns>
        public SecureUrl GetUrl(string path)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path cannot be empty", nameof(path));
            var host = _hosts[_shardingStrategy.GetShardId(path, _hostsCount)];
            return new SecureUrl(Scheme, host, path, _secureUrlToken);
        }

        private static string[] SanitizeHosts(string[] hosts)
        {
            var sanitizedHosts = new string[hosts.Length];
            for (var i = 0; i < hosts.Length; i++)
            {
                sanitizedHosts[i] = SanitizeHost(hosts[i]);
            }
            return sanitizedHosts;
        }

        private static string SanitizeHost(string host)
            => host.Contains(".") ? host : host + ".imgix.net";
    }
}