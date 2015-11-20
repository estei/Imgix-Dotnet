using System;
using Flurl;

namespace imgix_builder
{
    internal class ImgixBuilder : IImgixBuilder
    {
        internal ImgixBuilder(Url url)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            Url = url;
        }

        public string Url { get; }
        public IImgixBuilder AddParameter(string name, string value) => new ImgixBuilder(Url.SetQueryParam(name, value));
    }
}