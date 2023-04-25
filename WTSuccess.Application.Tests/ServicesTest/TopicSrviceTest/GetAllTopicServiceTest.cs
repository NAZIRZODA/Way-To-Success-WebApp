using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Application.Responses.TopicResponses;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.TopicServiceTest
{
    [TestFixture]
    public class GetAllTopicServiceTest
    {
        private TopicService _topicService;
        private Mock<ITopicRepository> _mockTopicrRepository;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockTopicrRepository = new Mock<ITopicRepository>();
            _mockMapper = new Mock<IMapper>();
            _topicService = new TopicService(_mockTopicrRepository.Object, _mockMapper.Object);
        }

        //[Test]
        //public void GetAll_ValidPageListAndPageNumber_ShouldReturnTopicResponseModels()
        //{
        //    // Arrange
        //    int pageList = 2;
        //    int pageNumber = 1;
        //    var topics = new List<Topic>
        //{
        //    new Topic { Id = 1, Name = "Topic 1" , Teory = "Test 1", ChapterId = 1},
        //    new Topic { Id = 2, Name = "Topic 2" , Teory = "Test 2", ChapterId = 2}
        //};
        //    _mockTopicrRepository.Setup(x => x.GetAll(pageList, pageNumber)).Returns(topics.AsQueryable());

        //    // Act
        //    var result = _topicService.GetAll(pageList, pageNumber);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsInstanceOf<IEnumerable<TopicResponseModel>>(result);
        //    Assert.AreEqual(topics.Count, result.Count());
        //    Assert.AreEqual(topics[0].Name, result.ElementAt(0).Name);
        //    Assert.AreEqual(topics[1].Teory, result.ElementAt(1).Teory);
        //    Assert.AreEqual(topics[1].ChapterId, result.ElementAt(1).ChapterId);
        //}

    }
}
