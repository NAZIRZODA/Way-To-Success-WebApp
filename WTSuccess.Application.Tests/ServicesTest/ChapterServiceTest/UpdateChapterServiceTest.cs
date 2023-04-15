using AutoMapper;
using Moq;
using NUnit.Framework;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.ChapterServiceTest
{
    [TestFixture]
    public class UpdateChapterServiceTest
    {
        private ChapterService _chapterService;
        private Mock<IChapterRepository> _mockChapterRepository;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockChapterRepository = new Mock<IChapterRepository>();
            _mockMapper = new Mock<IMapper>();
            _chapterService = new ChapterService(_mockChapterRepository.Object, _mockMapper.Object);
        }

        [Test]
        public void UpdateChapter_WithValidIdAndRequest_ReturnsChapterResponseModel()
        {
            ulong id = 1;
            var request = new UpdateChapterRequestModel { Name = "Updated Title" };
            var dbChapter = new Chapter { Id = id, Name = "Original Title" };
            var expectedResponse = new ChapterResponseModel { CourseId = id, Name = "Updated Title" };
            var mockRepository = new Mock<IChapterRepository>();
            var mockMapper = new Mock<IMapper>();
            mockRepository.Setup(x => x.FindById(id)).Returns(dbChapter);
            mockMapper.Setup(x => x.Map<UpdateChapterRequestModel, Chapter>(request, dbChapter))
                .Returns(dbChapter);
            mockMapper.Setup(x => x.Map<Chapter, ChapterResponseModel>(dbChapter))
                .Returns(expectedResponse);
            _chapterService = new ChapterService(mockRepository.Object, mockMapper.Object);
            var response = _chapterService.Update(id, request);
            Assert.AreEqual(expectedResponse.CourseId, response.CourseId);
            Assert.AreEqual(expectedResponse.Name, response.Name);
        }
    }
}
