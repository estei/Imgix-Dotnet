namespace imgix_builder
{
    public interface IImgixOptions
    {
        string SourceName { get; }
        bool UseHttps { get; }
    }
}