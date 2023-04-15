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
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.ChapterServiceTest
{
    [TestFixture]
    public class GetAllChapterServiceTest
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

        //[Test]
        //public void GetAll_ValidPageListAndPageNumber_ShouldReturnChapterResponseModels()
        //{
        //    // Arrange
        //    int pageList = 2;
        //    int pageNumber = 1;
        //    var chapters = new List<Chapter>
        //{
        //    new Chapter { Id = 1, Name = "Chapter 1" },
        //    new Chapter { Id = 2, Name = "Chapter 2" }
        //};
        //    _mockChapterRepository.Setup(x => x.GetAll(pageList, pageNumber)).Returns(chapters.AsQueryable());

        //    // Act
        //    var result = _chapterService.GetAll(pageList, pageNumber);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsInstanceOf<IEnumerable<ChapterResponseModel>>(result);
        //    Assert.AreEqual(chapters.Count, result.Count());
        //    Assert.AreEqual(chapters[0].Id, result.ElementAt(0).CourseId);
        //    Assert.AreEqual(chapters[0].Name, result.ElementAt(0).Name);
        //    Assert.AreEqual(chapters[1].Id, result.ElementAt(1).CourseId);
        //    Assert.AreEqual(chapters[1].Name, result.ElementAt(1).Name);
        //}

    }
}
