using AutoMapper;
using Moq;
using NUnit.Framework;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Requests.TopicRequests;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Application.Responses.TopicResponses;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.TopicServiceTest
{
    [TestFixture]
    public class UpdateTopicServiceTest
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
        public void UpdateTopic_WithValidIdAndRequest_ReturnsTopicResponseModel()
        {
            ulong id = 1;
            var request = new UpdateTopicRequestModel { Name = "Updated Title" , Teory = "Test", ChapterId = id};
            var dbTopic = new Topic { Id = id, Name = "Original Title", Teory = "Test", ChapterId = 1 };
            var expectedResponse = new TopicResponseModel { ChapterId = id, Name = "Updated Title", Teory = "Test" };
            var mockRepository = new Mock<ITopicRepository>();
            var mockMapper = new Mock<IMapper>();
            mockRepository.Setup(x => x.FindById(id)).Returns(dbTopic);
            mockMapper.Setup(x => x.Map<UpdateTopicRequestModel, Topic>(request, dbTopic))
                .Returns(dbTopic);
            mockMapper.Setup(x => x.Map<Topic, TopicResponseModel>(dbTopic))
                .Returns(expectedResponse);
            _topicService = new TopicService(mockRepository.Object, mockMapper.Object);
            var response = _topicService.Update(id, request);
            Assert.AreEqual(expectedResponse.ChapterId, response.ChapterId);
            Assert.AreEqual(expectedResponse.Name, response.Name);
            Assert.AreEqual(expectedResponse.Teory, response.Teory);
        }
    }
}
