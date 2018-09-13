using System.Configuration;

namespace ClearChannel.Base
{
    public class BasePage
    {
        /// <summary>
        ///     Get a fully qualified URL as defined by the AppSettings base url.
        /// </summary>
        /// <param name="uri">The URI to attach to the base URL.</param>
        /// <returns>The fully qualified page.</returns>
        public string GetUrl(string uri)
        {
            return ConfigurationManager.AppSettings.Get("baseurl") + uri;
        }
    }
}
