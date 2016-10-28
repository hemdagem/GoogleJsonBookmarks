using System.IO;

namespace GoogleJsonBookmarks.Domain
{
    public class FileHandler : IFileHandler
    {
        public string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public void WriteAllText(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}