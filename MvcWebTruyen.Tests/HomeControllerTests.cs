using MvcWebTruyen.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MvcWebTruyen.Tests.Controllers
{
    public class HomeControllerTests
    {
        private readonly Mock<ILogger<HomeController>> _mockLogger;

        public HomeControllerTests()
        {
            _mockLogger = new Mock<ILogger<HomeController>>();
        }

        [Fact]
        public void Index_Returns_ViewResult()
        {
            // Arrange
            var controller = new HomeController(_mockLogger.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Privacy_Returns_ViewResult()
        {
            // Arrange
            var controller = new HomeController(_mockLogger.Object);

            // Act
            var result = controller.Privacy();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
