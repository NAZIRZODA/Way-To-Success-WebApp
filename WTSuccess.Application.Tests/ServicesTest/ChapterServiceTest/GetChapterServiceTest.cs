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
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.ChapterServiceTest
{
    [TestFixture]
    public class GetChapterServiceTest
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
    }
}
