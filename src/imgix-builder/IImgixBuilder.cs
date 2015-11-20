namespace imgix_builder
{
    public interface IImgixBuilder
    {
        IImgixBuilder AddParameter(string name, string value);
        string Url { get; }
    }
}