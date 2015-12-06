using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    /// <summary>
    /// A collection of SourceElements
    /// </summary>
    public class SourcesCollection : ConfigurationElementCollection, IEnumerable<SourceElement>
    {
        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
            => new SourceElement();

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        /// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for. </param>
        protected override object GetElementKey(ConfigurationElement element)
            => ((SourceElement) element).Name;

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public new IEnumerator<SourceElement> GetEnumerator()
            => BaseGetAllKeys().Select(key => (SourceElement) BaseGet(key)).GetEnumerator();

        /// <summary>
        /// Creates a new IEnumerable of ImgixSources from this collection
        /// </summary>
        /// <returns>This collection as an IEnumerable og ImgixSources</returns>
        public IEnumerable<ImgixSource> ToImgixSourceEnumerable()
            => this.Select(sourceElement => sourceElement.ToImgixSource());
    }
}