using AutoMapper;
using FluentValidation.TestHelper;
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
using WTSuccess.Application.Validations.CourseValidations;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.CourseTests
{
    public class AddCourseTests
    {
        private readonly Mock<Common.Interfaces.Repositories.ICourseRepository> _mockCourseRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateCourseValidations _courseValidation;
        public AddCourseTests()
        {
            _mockCourseRepository = new Mock<Common.Interfaces.Repositories.ICourseRepository>();
            _mockMapper = new Mock<IMapper>();
            _courseValidation = new CreateCourseValidations();
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

        [Test]
        public void Exception_When_Name_is_longer_than18()
        {
            var requestCourse = new CreateCourseRequestModel()
            { Id = 1, Name = "C# is object oriented programming" };
            var result = _courseValidation.TestValidate(requestCourse);
            result.ShouldHaveValidationErrorFor(n => n.Name);
        }

        [Test]
        public void Exception_When_CourseRequest_is_Null()
        {
            var requestStudent = new CreateCourseRequestModel() { };
            var result = _courseValidation.TestValidate(requestStudent);
            result.ShouldHaveValidationErrorFor(result => result.Name);
        }
    }
}
