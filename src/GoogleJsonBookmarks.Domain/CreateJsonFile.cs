using System.IO;
using System.Linq;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using Newtonsoft.Json.Linq;

namespace GoogleJsonBookmarks.Domain
{
    public class CreateJsonFile
    {
        private readonly IFileHandler _fileHandler;
        private readonly IConfigHandler _configHandler;

        public CreateJsonFile(IFileHandler fileHandler, IConfigHandler configHandler)
        {
            _fileHandler = fileHandler;
            _configHandler = configHandler;
        }

        public CreateJsonFile() : this(new FileHandler(), new ConfigHandler())
        {

        }

        public bool Create()
        {
            if (!_fileHandler.FileExists(_configHandler.GoogleBookmarks))
            {
                throw new FileNotFoundException($"Could not find file: {_configHandler.GoogleBookmarks}");
            }
            string document = _fileHandler.ReadAllText(_configHandler.GoogleBookmarks);
            var parser = new HtmlParser();
            var htmlDocument = parser.Parse(document);

            JArray jsonArray = new JArray();
            foreach (IHtmlAnchorElement element in htmlDocument.QuerySelectorAll("dt > a")
                                            .Where(x => ((IHtmlAnchorElement)x)
                                            .Href.Contains("http://")))
            {

                jsonArray.Add(new JObject(
                                new JProperty("text", element.Text),
                                new JProperty("href", element.Href)
                   ));

            }
            _fileHandler.WriteAllText(_configHandler.JsonFileLocation, jsonArray.ToString());

            return true;
        }
    }
}
