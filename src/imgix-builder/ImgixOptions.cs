using System;

namespace imgix_builder
{
    public class ImgixOptions : IImgixOptions
    {
        public ImgixOptions(string sourceName)
        {
            if (sourceName == null) throw new ArgumentNullException(nameof(sourceName));
            SourceName = sourceName;
        }

        public string SourceName { get; }
    }
}