using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Imgix_Dotnet.Configuration.AppConfig
{
    /// <summary>
    /// A collection of hosts on a source
    /// </summary>
    public class HostsCollection :ConfigurationElementCollection, IEnumerable<HostElement>
    {
        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
            => new HostElement();

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        /// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for. </param>
        protected override object GetElementKey(ConfigurationElement element)
            => ((HostElement)element).HostName;

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public new IEnumerator<HostElement> GetEnumerator()
            => BaseGetAllKeys().Select(key => (HostElement)BaseGet(key)).GetEnumerator();
    }
}