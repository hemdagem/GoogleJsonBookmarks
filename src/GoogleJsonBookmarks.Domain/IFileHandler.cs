namespace GoogleJsonBookmarks.Domain
{
    public interface IFileHandler
    {
        string ReadAllText(string filePath);
        bool FileExists(string filePath);
        void WriteAllText(string filePath, string content);
    }
}