using System;
using System.Security.Cryptography;
using System.Text;

namespace Imgix_Dotnet
{
    /// <summary>
    /// A url that if given a token will signed with a parameter s=signature
    /// </summary>
    public class SecureUrl
    {
        private readonly string _scheme;
        private readonly string _path;
        private readonly string _host;
        private readonly string _secureUrlToken;
        private readonly string _parameters;

        /// <summary>
        /// Initializes a new instance of the SecureUrl class
        /// </summary>
        /// <param name="scheme">http or https</param>
        /// <param name="host">The hostname part of the url</param>
        /// <param name="path">The path of the url, this value must be percent escaped</param>
        /// <param name="secureUrlToken">The secure url token used for signing the url</param>
        internal SecureUrl(string scheme, string host, string path, string secureUrlToken)
            : this(scheme, host, path, secureUrlToken, "")
        {}

        /// <summary>
        /// Initializes a new instance of the SecureUrl class
        /// </summary>
        /// <param name="scheme">http or https</param>
        /// <param name="host">The hostname part of the url</param>
        /// <param name="path">The path of the url, this value must be percent escaped</param>
        /// <param name="secureUrlToken">The secure url token used for signing the url</param>
        /// <param name="parameters">The parameters of the url</param>
        internal SecureUrl(string scheme, string host, string path, string secureUrlToken, string parameters)
        {
            if (string.IsNullOrWhiteSpace(scheme)) throw new ArgumentException(nameof(scheme));
            if (string.IsNullOrWhiteSpace(host)) throw new ArgumentException(nameof(host));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException(nameof(path));
            if (secureUrlToken == null) throw new ArgumentNullException(nameof(secureUrlToken));
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            _scheme = scheme;
            _host = host;
            _secureUrlToken = secureUrlToken;
            _path = path.StartsWith("/") ? path : "/" + path;
            _parameters = parameters;
        }

        /// <summary>
        /// Adds a new parameter to the url
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The value of the parameter</param>
        /// <returns></returns>
        public SecureUrl AddParameter(string name, string value)
        {
            var escapedValue = Uri.EscapeDataString(value);
            var newParameter = CreateParameter(_parameters, name, escapedValue);
            return new SecureUrl(_scheme, _host, _path, _secureUrlToken, _parameters+newParameter);
        }

        private static string CreateSignatureParameter(string secureUrlToken, string path, string queryString)
            => string.IsNullOrWhiteSpace(secureUrlToken) ? "" : CreateParameter(queryString, "s", CreateSignature(secureUrlToken, path, queryString));

        private static string CreateParameter(string currentParameters, string name, string value)
            => $"{Paramstart(currentParameters)}{name}={value}";

        private static string Paramstart(string currentParameters)
            => string.IsNullOrEmpty(currentParameters) ? "?" : "&";

        private static string CreateSignature(string secureUrlToken, string path, string queryString)
        {
            var signatureBase = secureUrlToken + path;
            signatureBase = !string.IsNullOrWhiteSpace(queryString) ? signatureBase + queryString : signatureBase;
            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(signatureBase));
                var sBuilder = new StringBuilder();
                foreach (var hashedByte in data)
                {
                    sBuilder.Append(hashedByte.ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
            => $"{_scheme}://{_host}{_path}{_parameters}{CreateSignatureParameter(_secureUrlToken, _path, _parameters)}";

        /// <summary>
        /// Implicit conversion from SecureUrl to string
        /// </summary>
        /// <param name="secureUrl">The secureUrl to convert</param>
        /// <returns></returns>
        public static implicit operator string (SecureUrl secureUrl) => secureUrl.ToString();
    }
}