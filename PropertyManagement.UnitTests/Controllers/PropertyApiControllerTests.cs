using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using PropertyManagement.Helper.Models;
using PropertyManagement.WebAPI.Controllers;
using PropertyManagement.WebAPI.Services;

namespace PropertyManagement.UnitTests.Controllers
{
    public class PropertyApiControllerTests
    {
        private readonly Mock<IStorageService> _storageServiceMock;
        private readonly Mock<IOptions<AppSettings>> _appSettingsMock;
        private readonly AppSettings _appSettings;
        private readonly PropertyApiController _controller;

        public PropertyApiControllerTests()
        {
            _storageServiceMock = new Mock<IStorageService>();
            _appSettings = new AppSettings
            {
                BlobStorageSettings = new BlobStorageSettings
                {
                    ContainerName = "test-container",
                    BlobName = "test-blob"
                }
            };
            _appSettingsMock = new Mock<IOptions<AppSettings>>();
            _appSettingsMock.Setup(x => x.Value).Returns(_appSettings);

            _controller = new PropertyApiController(_storageServiceMock.Object, _appSettingsMock.Object);
        }

        [Fact]
        public async Task GetAsync_ReturnsOk_WhenPropertiesExist()
        {
            // Arrange
            var properties = new List<PropertyModel> { new PropertyModel() };
            _storageServiceMock
                .Setup(s => s.GetPropertiesAsync(_appSettings.BlobStorageSettings.ContainerName, _appSettings.BlobStorageSettings.BlobName))
                .ReturnsAsync(properties);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(properties, okResult.Value);
        }

        [Fact]
        public async Task GetAsync_ReturnsNotFound_WhenNoPropertiesExist()
        {
            // Arrange
            _storageServiceMock
                .Setup(s => s.GetPropertiesAsync(_appSettings.BlobStorageSettings.ContainerName, _appSettings.BlobStorageSettings.BlobName))
                .ReturnsAsync(new List<PropertyModel>());

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAsync_ThrowsArgumentNullException_WhenContainerNameIsNull()
        {
            // Arrange
            _appSettings.BlobStorageSettings.ContainerName = null!;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _controller.GetAsync());
        }

        [Fact]
        public async Task GetAsync_ThrowsArgumentNullException_WhenBlobNameIsNull()
        {
            // Arrange
            _appSettings.BlobStorageSettings.BlobName = null!;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _controller.GetAsync());
        }

        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenStorageServiceIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new PropertyApiController(null!, _appSettingsMock.Object));
        }

        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenAppSettingsIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new PropertyApiController(_storageServiceMock.Object, null!));
        }
    }
}