namespace GoogleJsonBookmarks.Domain
{
    public interface IConfigHandler
    {
        string JsonFileLocation { get; }
        string GoogleBookmarks { get; }

    }
}