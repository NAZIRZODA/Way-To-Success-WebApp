
using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Net;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.TopicRequests;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.TopicServiceTest
{
    [TestFixture]
    public class AddTopicServiceTest
    {
        private TopicService _topicService;
        private Mock<ITopicRepository> _mockTopicRepository;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockTopicRepository = new Mock<ITopicRepository>();
            _mockMapper = new Mock<IMapper>();
            _topicService = new TopicService(_mockTopicRepository.Object, _mockMapper.Object);
        }

        [Test]
        public void Add_ValidRequest_ShouldAddTopicToRepository()
        {
            // Arrange
            var request = new CreateTopicRequestModel { Name = "Topic 1", Teory = "Test", ChapterId = 1 };

            // Act
            _topicService.Add(request);
            // Assert
            _mockTopicRepository.Verify(x => x.Add(It.IsAny<Topic>()), Times.Once);
            _mockTopicRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void Add_InvalidRequest_ShouldThrowHttpStatusCodeException()
        {
            // Arrange
            CreateTopicRequestModel request = null;

            // Act & Assert
            var ex = Assert.Throws<HttpStatusCodeException>(() => _topicService.Add(request));
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.Message, Is.EqualTo(nameof(Student)));
        }
    }
}
