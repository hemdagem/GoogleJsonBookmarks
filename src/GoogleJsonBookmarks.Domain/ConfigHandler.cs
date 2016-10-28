using System.Configuration;

namespace GoogleJsonBookmarks.Domain
{
    public class ConfigHandler : IConfigHandler
    {
        public string JsonFileLocation
        {
            get { return ConfigurationManager.AppSettings["JsonFileLocation"];  }
        }

        public string GoogleBookmarks
        {
            get { return ConfigurationManager.AppSettings["GoogleBookmarks"]; }
        }
    }
}