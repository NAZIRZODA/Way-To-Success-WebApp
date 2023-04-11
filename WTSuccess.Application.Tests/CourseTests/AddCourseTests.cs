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
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.CourseTests
{
    public class AddCourseTests
    {
        private readonly Mock<Common.Interfaces.Repositories.ICourseRepository> _mockCourseRepository;
        private readonly Mock<IMapper> _mockMapper;
        public AddCourseTests()
        {
            _mockCourseRepository = new Mock<Common.Interfaces.Repositories.ICourseRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test]
        public void Add_Course()
        {
            CreateCourseRequestModel createCourseRequestModel = new CreateCourseRequestModel() { Name = "C#" };
            Course course = new Course() { Name = "C#" };

            _mockMapper.Setup(service => service.Map<CreateCourseRequestModel, Course>(createCourseRequestModel))
                .Returns(course);


            _mockCourseRepository.Setup(service => service.Add(It.IsAny<Course>()));

            var service = new CourseService(_mockCourseRepository.Object, _mockMapper.Object);
            service.Add(createCourseRequestModel);
            _mockCourseRepository.Verify(a => a.Add(It.IsAny<Course>()));
            _mockCourseRepository.Verify(a => a.SaveChanges());
        }
    }
}
