

using AutoMapper;
using Moq;
using NUnit.Framework;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.TopicServiceTest
{
    [TestFixture]
    public class DeleteTopicServiceTest
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
        public void Delete_TopicExists_ShouldDeleteAndReturnTrue()
        {
            // Arrange
            ulong id = 1;
            var dbTopic = new Topic { Id = id, Name = "Topic to delete", Teory = "Test", ChapterId = 1 };
            _mockTopicRepository.Setup(x => x.FindById(id)).Returns(dbTopic);
            // Act
            var result = _topicService.Delete(id);

            // Assert
            Assert.IsTrue(result);
            _mockTopicRepository.Verify(x => x.Delete(dbTopic), Times.Once);
            _mockTopicRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void Delete_TopicDoesNotExist_ShouldThrowHttpStatusCodeException()
        {
            // Arrange  
            ulong id = 1;
            _mockTopicRepository.Setup(x => x.FindById(id)).Returns((Topic)null);
            // Act & Assert
            Assert.Throws<HttpStatusCodeException>(() => _topicService.Delete(id));
            _mockTopicRepository.Verify(x => x.Delete(It.IsAny<Topic>()), Times.Never);
            _mockTopicRepository.Verify(x => x.SaveChanges(), Times.Never);
        }
    }
}
