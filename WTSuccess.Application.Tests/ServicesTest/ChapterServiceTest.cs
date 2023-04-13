using AutoMapper;
using Moq;
using System.Net;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;
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
            CreateChapterRequestModel request = null;

            // Act & Assert
            var ex = Assert.Throws<HttpStatusCodeException>(() => _chapterService.Add(request));
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.Message, Is.EqualTo(nameof(Student)));
        }

        [Test]
        public void Get_ExistingChapterId_ShouldReturnChapterResponseModel()
        {
            // Arrange
            ulong chapterId = 1;
            ulong courseId = 2;
            var chapter = new Chapter { Id = chapterId, Name = "Chapter 1", CourseId = courseId };
            _mockChapterRepository.Setup(x => x.FindById(chapterId)).Returns(chapter);
            _mockMapper.Setup(m => m.Map<Chapter, ChapterResponseModel>(chapter))
                .Returns(new ChapterResponseModel() { Name = "Chapter 1", CourseId = courseId });

            var chapterService = new ChapterService(_mockChapterRepository.Object, _mockMapper.Object);
            // Act

            ChapterResponseModel result = chapterService.Get(chapterId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.CourseId, Is.EqualTo(courseId));
            Assert.That(result.Name, Is.EqualTo(chapter.Name));
        }

        [Test]
        public void Get_NonExistingChapterId_ShouldThrowHttpStatusCodeException()
        {
            // Arrange
            ulong chapterId = 1;
            _mockChapterRepository.Setup(x => x.FindById(chapterId)).Returns((Chapter)null);

            // Act & Assert
            var ex = Assert.Throws<HttpStatusCodeException>(() => _chapterService.Get(chapterId));
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.Message, Is.EqualTo(nameof(Student)));
        }
        //    [Test]
        //    public void GetAll_ValidPageListAndPageNumber_ShouldReturnChapterResponseModels()
        //    {
        //        // Arrange
        //        int pageList = 2;
        //        int pageNumber = 1;
        //        var chapters = new List<Chapter>
        //{
        //    new Chapter { Id = 1, Name = "Chapter 1" },
        //    new Chapter { Id = 2, Name = "Chapter 2" }
        //};
        //        _mockChapterRepository.Setup(x => x.GetAll(pageList, pageNumber)).Returns(chapters.AsQueryable());

        //        // Act
        //        var result = _chapterService.GetAll(pageList, pageNumber);

        //        // Assert
        //        Assert.IsNotNull(result);
        //        Assert.IsInstanceOf<IEnumerable<ChapterResponseModel>>(result);
        //        Assert.AreEqual(chapters.Count, result.Count());
        //        Assert.AreEqual(chapters[0].Id, result.ElementAt(0).CourseId);
        //        Assert.AreEqual(chapters[0].Name, result.ElementAt(0).Name);
        //        Assert.AreEqual(chapters[1].Id, result.ElementAt(1).CourseId);
        //        Assert.AreEqual(chapters[1].Name, result.ElementAt(1).Name);
        //    }


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

        [Test]
        public void Delete_ChapterExists_ShouldDeleteAndReturnTrue()
        {
            // Arrange
            ulong id = 1;
            var dbChapter = new Chapter { Id = id, Name = "Chapter to delete" };
            _mockChapterRepository.Setup(x => x.FindById(id)).Returns(dbChapter);
            // Act
            var result = _chapterService.Delete(id);

            // Assert
            Assert.IsTrue(result);
            _mockChapterRepository.Verify(x => x.Delete(dbChapter), Times.Once);
            _mockChapterRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void Delete_ChapterDoesNotExist_ShouldThrowHttpStatusCodeException()
        {
            // Arrange
            ulong id = 1;
            _mockChapterRepository.Setup(x => x.FindById(id)).Returns((Chapter)null);
            // Act & Assert
            Assert.Throws<HttpStatusCodeException>(() => _chapterService.Delete(id));
            _mockChapterRepository.Verify(x => x.Delete(It.IsAny<Chapter>()), Times.Never);
            _mockChapterRepository.Verify(x => x.SaveChanges(), Times.Never);
        }
    }
}