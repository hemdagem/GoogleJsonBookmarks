using System.IO;
using GoogleJsonBookmarks.Domain;
using Moq;
using NUnit.Framework;

namespace GoogleJsonBookmarks.UnitTests
{
    [TestFixture]
    public class CreateJsonFileTests
    {
        Mock<IFileHandler> fileHandler = new Mock<IFileHandler>();
        Mock<IConfigHandler> configHandler = new Mock<IConfigHandler>();
        private Domain.CreateJsonFile createJsonFile;
        [SetUp]
        public void Setup()
        {
            createJsonFile = new CreateJsonFile(fileHandler.Object, configHandler.Object);
        }

        [Test]
        public void CreateJsonFile_should_throw_exception_when_file_does_not_exist()
        {
            fileHandler.Setup(x => x.FileExists(It.IsAny<string>())).Returns(false);


            Assert.Throws<FileNotFoundException>(() => createJsonFile.Create());
        }
    }
}
