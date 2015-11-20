using System;

namespace imgix_builder
{
    public class ImgixOptions : IImgixOptions
    {
        public ImgixOptions(string sourceName, bool useHttps = true)
        {
            if (sourceName == null) throw new ArgumentNullException(nameof(sourceName));
            SourceName = sourceName;
            UseHttps = useHttps;
        }

        public string SourceName { get; }
        public bool UseHttps { get; }
    }
}