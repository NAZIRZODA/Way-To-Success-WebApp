using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Application.Responses.TopicResponses;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.TopicServiceTest
{
    [TestFixture]
    public class GetTopicServiceTest
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
        public void Get_ExistingTopicId_ShouldReturnTopicResponseModel()
        {
            // Arrange
            ulong chapterId = 1;
            ulong topicId = 1;
            var topic = new Topic { Id = topicId, Name = "Topic 1", Teory = "Test", ChapterId = chapterId };
            _mockTopicRepository.Setup(x => x.FindById(topicId)).Returns(topic);
            _mockMapper.Setup(m => m.Map<Topic, TopicResponseModel>(topic))
                .Returns(new TopicResponseModel() { Name = "Topic 1", Teory = "Test", ChapterId = chapterId });

            var topicService = new TopicService(_mockTopicRepository.Object, _mockMapper.Object);
            // Act

            TopicResponseModel result = topicService.Get(topicId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.ChapterId, Is.EqualTo(chapterId));
            Assert.That(result.Name, Is.EqualTo(topic.Name));
            Assert.That(result.Teory, Is.EqualTo(topic.Teory));
        }

        [Test]
        public void Get_NonExistingTopicId_ShouldThrowHttpStatusCodeException()
        {
            // Arrange
            ulong topicId = 1;
            _mockTopicRepository.Setup(x => x.FindById(topicId)).Returns((Topic)null);

            // Act & Assert
            var ex = Assert.Throws<HttpStatusCodeException>(() => _topicService.Get(topicId));
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.Message, Is.EqualTo(nameof(Student)));
        }
    }
}
