using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class IstallerHelperTests
    {
        private Mock<IFileDownloader> _downloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void Setup()
        {
            _downloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_downloader.Object);
        }

        [Test]
        public void DownloadInstaller_DawnloadFalis_ReturnFalse()
        {
            _downloader.Setup(fd => 
                   fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                   .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.IsFalse(result);
        }
        
        [Test]
        public void DownloadInstaller_DawnloadFCompletes_ReturnTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.IsTrue(result);
        }
    }
}
