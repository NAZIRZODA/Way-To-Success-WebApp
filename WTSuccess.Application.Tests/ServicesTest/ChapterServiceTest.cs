using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace WTSuccess.UnitTests.Application.Services
{
    [TestFixture]
    public class ChapterServiceTests
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
        public void Add_ValidRequest_ShouldAddChapterToRepository()
        {
            // Arrange
            var request = new CreateChapterRequestModel { Name = "Chapter 1" };

            // Act
            _chapterService.Add(request);

            // Assert
            _mockChapterRepository.Verify(x => x.Add(It.IsAny<Chapter>()), Times.Once);
            _mockChapterRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void Add_InvalidRequest_ShouldThrowHttpStatusCodeException()
        {
            // Arrange
            var request = new UpdateChapterRequestModel { Name = "Chapter 1" };

            // Act & Assert
            var ex = Assert.Throws<HttpStatusCodeException>(() => _chapterService.Add(request));
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);
            Assert.AreEqual(nameof(Student), ex.Message);
        }
        //[Test]
        //public void Get_ExistingChapterId_ShouldReturnChapterResponseModel()
        //{
        //    // Arrange
        //    ulong chapterId = 1;
        //    var chapter = new Chapter { Id = chapterId, Name = "Chapter 1" };
        //    _mockChapterRepository.Setup(x => x.FindById(chapterId)).Returns(chapter);
        //    var chapterService = new ChapterService(_mockChapterRepository.Object, _mockMapper.Object);
        //    // Act
        //    ChapterResponseModel result = chapterService.Get(chapterId);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(chapterId, result.CourseId);
        //    Assert.AreEqual(chapter.Name, result.Name);
        //}

        [Test]
        public void Get_NonExistingChapterId_ShouldThrowHttpStatusCodeException()
        {
            // Arrange
            ulong chapterId = 1;
            _mockChapterRepository.Setup(x => x.FindById(chapterId)).Returns((Chapter)null);

            // Act & Assert
            var ex = Assert.Throws<HttpStatusCodeException>(() => _chapterService.Get(chapterId));
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);
            Assert.AreEqual(nameof(Student), ex.Message);
        }
    }
}