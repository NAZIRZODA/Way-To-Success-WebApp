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
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.ChapterServiceTest
{
    [TestFixture]
    public class AddChapterServiceTest
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
    }
}
