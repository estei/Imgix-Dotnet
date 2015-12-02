using System;
using System.Globalization;

namespace Imgix_Dotnet.Extensions.ObjectInvariantConversion
{
    /// <summary>
    /// Object extensions
    /// </summary>
    public static class ObjectToInvarianString
    {
        //Source: https://github.com/tmenier/Flurl/blob/master/Flurl/Util/CommonExtensions.cs
        /// <summary>
		/// Returns a string that represents the current object, using CultureInfo.InvariantCulture where possible.
		/// </summary>
		public static string ToInvariantString(this object sourceObject)
        {
            var convertible = sourceObject as IConvertible;
            if (convertible != null)
            {
                return convertible.ToString(CultureInfo.InvariantCulture);
            }
            var formattable = sourceObject as IFormattable;
            return formattable?.ToString(null, CultureInfo.InvariantCulture) ?? sourceObject.ToString();
        }
    }
}