using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.CourseRequests;
using WTSuccess.Application.Responses.CourseRespnses;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.CourseTests
{
    public class UpdateCourseTests
    {
        private readonly Mock<ICourseRepository> _courseRepositoryMock;
        private readonly Mock<IMapper> _mockMapper;
        public UpdateCourseTests()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test]
        public void Update_Course()
        {
            UpdateCourseRequestModel updateCourseRequestModel = new UpdateCourseRequestModel()
            {
                Id = 1,
                Name = "PHP"
            };
            Course course = new Course()
            { Id = 1, Name = "PHP" };

            CourseResponseModel courseResponseModel = new CourseResponseModel() { Name = "PHP" };

            _mockMapper.Setup(ser => ser.Map<UpdateCourseRequestModel, Course>(updateCourseRequestModel))
                .Returns(course);
            _mockMapper.Setup(service => service.Map<Course, CourseResponseModel>(course))
                .Returns(courseResponseModel);
            _courseRepositoryMock.Setup(service => service.Update(It.IsAny<Course>()));
            _courseRepositoryMock.Setup(service => service.FindById(It.IsAny<ulong>()))
                .Returns(course);

            var result = new CourseService(_courseRepositoryMock.Object, _mockMapper.Object);
            var response = result.Update(1, updateCourseRequestModel);

            _courseRepositoryMock.Verify(service => service.Update(It.IsAny<Course>()));
            _courseRepositoryMock.Verify(service => service.FindById(It.IsAny<ulong>()));
            _courseRepositoryMock.Verify(service => service.SaveChanges());

            Assert.That(courseResponseModel.Name, Is.EqualTo(response.Name));
        }
    }
}