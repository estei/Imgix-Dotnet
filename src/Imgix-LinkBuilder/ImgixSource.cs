using System;

namespace Imgix_LinkBuilder
{
    /// <summary>
    /// An imgix source
    /// </summary>
    public class ImgixSource
    {
        private readonly string[] _hosts;
        private readonly ShardingStrategy _shardingStrategy;
        private int _hostsCycleCounter;
        private readonly int _hostsCount;

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
        public ImgixSource(string name, string secureUrlToken, string host, bool isHttps) : this(name, secureUrlToken, new[] { host }, isHttps, ShardingStrategy.None)
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
        public ImgixSource(string name, string[] hosts, bool isHttps, ShardingStrategy shardingStrategy)
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
        public ImgixSource(string name, string secureUrlToken, string[] hosts, bool isHttps, ShardingStrategy shardingStrategy)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
            if (secureUrlToken == null) throw new ArgumentNullException(nameof(secureUrlToken)+" cannot be null", nameof(secureUrlToken));
            if (hosts.Length == 0) throw new ArgumentException("Must define atleast one host", nameof(hosts));
            if (!Enum.IsDefined(typeof (ShardingStrategy), shardingStrategy))
                throw new ArgumentOutOfRangeException(nameof(shardingStrategy)+" is not a valid sharding strategy", nameof(shardingStrategy));
            Name = name;
            SecureUrlToken = secureUrlToken;
            IsHttps = isHttps;
            _hosts = SanitizeHosts(hosts);
            _shardingStrategy = shardingStrategy;
            _hostsCycleCounter = 0;
            _hostsCount = _hosts.Length;
        }

        /// <summary>
        /// The name of the source
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Is this source https
        /// </summary>
        public bool IsHttps { get; }

        /// <summary>
        /// Secure Url token used for signing image urls
        /// </summary>
        public string SecureUrlToken { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public SecureUrl GetUrl(string path)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path cannot be empty", nameof(path));
            switch (_shardingStrategy)
            {
                case ShardingStrategy.None:
                    return CreateUrlFromPath(_hosts[0], path);
                case ShardingStrategy.Cycle:
                    return CreateUrlFromPath(GetNextHostInCycle(), path);
                case ShardingStrategy.Hash:
                    return CreateUrlFromPath(GetHostFromPathHash(path), path);
                default:
                    return CreateUrlFromPath(_hosts[0], path);
            }
        }

        private string GetHostFromPathHash(string path)
        {
            var pos = Math.Abs(path.GetHashCode())%_hostsCount;
            return _hosts[pos];
        }

        private string GetNextHostInCycle()
        {
            var host = _hosts[_hostsCycleCounter];
            _hostsCycleCounter = (_hostsCycleCounter + 1)%_hostsCount;
            return host;
        }

        private SecureUrl CreateUrlFromPath(string host, string path)
            => new SecureUrl(IsHttps ? "https" : "http", host, path, SecureUrlToken, "");

        private static string[] SanitizeHosts(string[] hosts)
        {
            var sanitizedHosts = new string[hosts.Length];
            for (var i = 0; i < hosts.Length-1; i++)
            {
                sanitizedHosts[i] = SanitizeHost(hosts[i]);
            }
            return sanitizedHosts;
        }

        private static string SanitizeHost(string host)
            => host.Contains(".") ? host : host + ".imgix.net";
    }
}