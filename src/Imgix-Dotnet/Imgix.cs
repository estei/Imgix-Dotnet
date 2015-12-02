using System;
using System.Collections.Generic;
using System.Linq;
using Imgix_Dotnet.Configuration;

namespace Imgix_Dotnet
{
    /// <summary>
    /// The Imgix url builder.
    /// </summary>
    public class Imgix
    {
        private readonly Dictionary<string, ImgixSource> _sources;
        /// <summary>
        /// The base constructor.
        /// Sets up the Imgix url builder base options.
        /// </summary>
        /// <param name="options"></param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> is empty</exception>
        public Imgix(IImgixOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (!options.Sources.Any()) throw new ArgumentException(nameof(options)+" You must define at least one source", nameof(options));
            _sources = options.Sources.ToDictionary(source => source.Name, source => source);
        }

        /// <summary>
        /// Creates a new imgix image from with the options in this Imgix
        /// Caution: Will only ever grab the first source. If you have multiple sources it is receommended to use the overload with sourceName
        /// </summary>
        /// <param name="path">The path to the image</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="path"/> is null or whitespace. </exception>
        public ImgixImage NewImage(string path)
        {
            var sourceName = _sources.First().Value.Name;
            return NewImage(sourceName, path);
        }

        /// <summary>
        /// Creates a new imgix image from with the options in this Imgix
        /// </summary>
        /// <param name="sourceName">The name of the source to use</param>
        /// <param name="path">The path to the image</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        ///     <para><paramref name="sourceName"/> is null or whitespace. </para>
        ///     <para>- or - </para>
        ///     <para><paramref name="path"/> is null or whitespace. </para>
        /// </exception>
        /// <exception cref="KeyNotFoundException">There is no source with name in <paramref name="sourceName"/></exception>
        public ImgixImage NewImage(string sourceName, string path)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Argument is null or whitespace", nameof(path));
            if (String.IsNullOrWhiteSpace(sourceName))
                throw new ArgumentException("Argument is null or whitespace", nameof(sourceName));
            var escapedPath = path.StartsWith("http") ? Uri.EscapeDataString(path) : Uri.EscapeUriString(path).Replace("?", "%3F");
            ImgixSource source;
            if (!_sources.TryGetValue(sourceName, out source)) { throw new KeyNotFoundException($"No source named {sourceName} found");}
            return new ImgixImage(source.GetUrl(escapedPath));
        }

        /// <summary>
        /// Creates a new imgix image from a supplied options object
        /// </summary>
        /// <param name="options">The base options</param>
        /// <param name="path">The path to the image</param>
        /// <returns></returns>
        public static ImgixImage CreateImage(IImgixOptions options, string path)
            => new Imgix(options).NewImage(path);

        /// <summary>
        /// Creates a new unsigned imgix image from a supplied sourceName and path
        /// </summary>
        /// <param name="path">The path to the image</param>
        /// <param name="host">The host of the source</param>
        /// <param name="useHttps">Is the source https. Default: true</param>
        /// <returns></returns>
        public static ImgixImage CreateImage(string path, string host, bool useHttps = true)
            => CreateImage(new ImgixOptions(new ImgixSource("Anonomous", host, useHttps)), path);
    }
}