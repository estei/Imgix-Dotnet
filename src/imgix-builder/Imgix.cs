using Flurl;

namespace imgix_builder
{
    public class Imgix
    {
        private readonly string _source;

        public Imgix(IImgixOptions options)
        {
            _source = options.SourceName;
        }

        public IImgixBuilder NewImage(string path) => new ImgixBuilder(new Url($"https://{_source}.imgix.net".AppendPathSegment(path)));

        public static IImgixBuilder NewImage(IImgixOptions options, string path) => new Imgix(options).NewImage(path);
    }
}