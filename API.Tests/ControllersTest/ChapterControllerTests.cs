using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.API.Controllers;

namespace WTSuccess.UnitTests.Controllers
{
    [TestFixture]
    public class ChapterControllerTests
    {
        private Mock<IChapterService> _mockChapterService;
        private ChapterController _controller;

        [SetUp]
        public void Setup()
        {
            _mockChapterService = new Mock<IChapterService>();
            _controller = new ChapterController(_mockChapterService.Object);
        }

        [Test]
        public void Get_ReturnsChapterResponseModelList()
        {
            var pageList = 10;
            var pageNumber = 1;
            var expected = new List<ChapterResponseModel>
            {
                new ChapterResponseModel { CourseId = 1, Name = "Chapter 1" },
                new ChapterResponseModel { CourseId = 2, Name = "Chapter 2" },
                new ChapterResponseModel { CourseId = 3, Name = "Chapter 3" }
            };
            _mockChapterService.Setup(x => x.GetAll(pageList, pageNumber)).Returns(expected);

            var result = _controller.Get(pageList, pageNumber);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Get_ReturnsChapterResponseModel()
        {
            var id = 1ul;
            var expected = new ChapterResponseModel { CourseId = id, Name = "Chapter 1" };
            _mockChapterService.Setup(x => x.Get(id)).Returns(expected);

            var result = _controller.Get(id);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Post_CallsAddWithCreateChapterRequestModel()
        {
            var chapter = new CreateChapterRequestModel { Name = "Chapter 1" };

            _controller.Post(chapter);

            _mockChapterService.Verify(x => x.Add(chapter), Times.Once);
        }

        [Test]
        public void Put_CallsUpdateWithIdAndUpdateChapterRequestModel()
        {
            var id = 1ul;
            var chapter = new UpdateChapterRequestModel { Name = "Chapter 1" };

            _controller.Put(id, chapter);

            _mockChapterService.Verify(x => x.Update(id, chapter), Times.Once);
        }

        [Test]
        public void Delete_CallsDeleteWithId()
        {
            var id = 1ul;

            _controller.Delete(id);

            _mockChapterService.Verify(x => x.Delete(id), Times.Once);
        }
    }
}
