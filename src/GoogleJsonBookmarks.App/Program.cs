using GoogleJsonBookmarks.Domain;

namespace GoogleJsonBookmarks.App
{
    class Program
    {
        static void Main(string[] args)
        {
            new CreateJsonFile().Create();
        }
    }
}
