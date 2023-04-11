using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
    [TestClass]
    public class ChapterServiceTests
    {
        private ChapterService _chapterService;
        private Mock<IChapterRepository> _mockChapterRepository;
        private Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Setup()
        {
            _mockChapterRepository = new Mock<IChapterRepository>();
            _mockMapper = new Mock<IMapper>();
            _chapterService = new ChapterService(_mockChapterRepository.Object, _mockMapper.Object);
        }

        [Test]
        public void Add_WithValidRequest_CallsRepositoryAddAndSaveChanges()
        {
            var request = new CreateChapterRequestModel();
            var chapter = new Chapter();
            _mockMapper.Setup(x => x.Map<CreateChapterRequestModel, Chapter>(request)).Returns(chapter);

            _chapterService.Add(request);

            _mockChapterRepository.Verify(x => x.Add(chapter), Times.Once);
            _mockChapterRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        [ExpectedException(typeof(HttpStatusCodeException))]
        public void Add_WithInvalidRequest_ThrowsHttpStatusCodeException()
        {
            var request = new UpdateChapterRequestModel();

            _chapterService.Add(request);
        }
        [Test]
        public void Get_ReturnsCorrectChapter()
        {
            var chapterId = 1;
            var expectedChapter = new Chapter { Id = (ulong)chapterId, Name = "Chapter 1" };
            var mockRepository = new Mock<IChapterRepository>();
            mockRepository.Setup(repo => repo.FindById((ulong)chapterId)).Returns(expectedChapter);
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(mapper => mapper.Map<Chapter, ChapterResponseModel>(It.IsAny<Chapter>())).Returns(new ChapterResponseModel());
            var chapterService = new ChapterService(mockRepository.Object, mockMapper.Object);

            var result = chapterService.Get((ulong)chapterId);

            Assert.IsNotNull(result);
            mockRepository.Verify(repo => repo.FindById((ulong)chapterId), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<Chapter, ChapterResponseModel>(It.IsAny<Chapter>()), Times.Once);
        }
        [Test]
        public void GetAll_ReturnsAllChapters()
        {
            var mockRepository = new Mock<IChapterRepository>();
            var mockMapper = new Mock<IMapper>();

            var expectedChapters = new List<Chapter>
            {
                new Chapter { Id = 1, Name = "Chapter 1" },
                new Chapter { Id = 2, Name = "Chapter 2" },
                new Chapter { Id = 3, Name = "Chapter 3" }
            };

            mockRepository.Setup(x => x.GetAll(It.IsAny<int>(), It.IsAny<int>())).Returns((IQueryable<Chapter>)expectedChapters);

            var expectedResponseModels = expectedChapters.Select(c => new ChapterResponseModel { CourseId = c.Id, Name = c.Name });

            mockMapper.Setup(x => x.Map<IEnumerable<Chapter>, IEnumerable<ChapterResponseModel>>(expectedChapters))
                .Returns(expectedResponseModels);

            var service = new ChapterService(mockRepository.Object, mockMapper.Object);
            var result = service.GetAll(10, 1);
            Assert.NotNull(result);
            Assert.AreEqual(expectedResponseModels.Count(), result.Count());
            Assert.AreEqual(expectedResponseModels, result);
        }
        [Test]
        public void UpdateChapter_WithValidIdAndRequest_ReturnsChapterResponseModel()
        {
            ulong id = 1;
            var request = new UpdateChapterRequestModel { Name = "Updated Title"};
            var dbChapter = new Chapter { Id = id, Name = "Original Title"};
            var expectedResponse = new ChapterResponseModel { CourseId = id, Name = "Updated Title"};
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
        [ExpectedException(typeof(HttpStatusCodeException))]
        public void UpdateChapter_WithInvalidId_ThrowsHttpStatusCodeException()
        {
            var id = 1;
            var request = new UpdateChapterRequestModel { Name = "Updated Title"};
            Chapter dbChapter = null;
            var mockRepository = new Mock<IChapterRepository>();
            var mockMapper = new Mock<IMapper>();
            mockRepository.Setup(x => x.FindById((ulong)id)).Returns(dbChapter);
            _chapterService = new ChapterService(mockRepository.Object, mockMapper.Object);
            _chapterService.Update((ulong)id, request);
        }
        [Test]
        public void Delete_ShouldReturnTrue_WhenChapterExists()
        {
            var chapterToDelete = new Chapter { Id = 1 };

            _mockChapterRepository.Setup(x => x.FindById(1)).Returns(chapterToDelete);

            var result = _chapterService.Delete(1);

            Assert.IsTrue(result);
            _mockChapterRepository.Verify(x => x.Delete(chapterToDelete), Times.Once);
            _mockChapterRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void Delete_ShouldThrowHttpStatusCodeException_WhenChapterDoesNotExist()
        {
            ulong chapterId = 1;
            _mockChapterRepository.Setup(x => x.FindById(1)).Returns((Chapter)null);

            Assert.Throws<HttpStatusCodeException>(() => _chapterService.Delete(1));
        }
    }
}