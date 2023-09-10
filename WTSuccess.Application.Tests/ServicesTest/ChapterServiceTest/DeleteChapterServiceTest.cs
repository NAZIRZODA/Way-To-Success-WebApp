using AutoMapper;
using Moq;
using NUnit.Framework;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.ChapterServiceTest
{
    [TestFixture]
    public class DeleteChapterServiceTest
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
