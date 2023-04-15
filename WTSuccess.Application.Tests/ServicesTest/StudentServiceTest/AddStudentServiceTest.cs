using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Requests.StudentRequests;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.StudentServiceTest
{
    [TestFixture]
    public class AddStudentServiceTest
    {
        private StudentService _studentService;
        private Mock<IStudentRepository> _mockStudentRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<ICourseRepository> _mockCourseRepository;

        [SetUp]
        public void Setup()
        {
            _mockStudentRepository = new Mock<IStudentRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockCourseRepository = new Mock<ICourseRepository>();
            _studentService = new StudentService(_mockStudentRepository.Object, _mockCourseRepository.Object, _mockMapper.Object);
        }

        [Test]
        public void Add_ValidCreateStudentRequestModel_AddsStudentToRepository()
        {
            // Arrange
            var request = new CreateStudentRequestModel
            {
                Name = "John",
                Surname = "Doe",
                Email = "Johndoe@gmail.com",
                Password = "211324",
                Gender = true
            };
            var mockMapper = new Mock<IMapper>();
            var mockStudentRepository = new Mock<IStudentRepository>();
            var mockCourseRepository = new Mock<ICourseRepository>();
            var service = new StudentService(mockStudentRepository.Object, mockCourseRepository.Object, mockMapper.Object);

            // Act
            service.Add(request);

            // Assert
            mockMapper.Verify(m => m.Map<CreateStudentRequestModel, Student>(request), Times.Once);
            mockStudentRepository.Verify(m => m.Add(It.IsAny<Student>()), Times.Once);
            mockStudentRepository.Verify(m => m.SaveChanges(), Times.Once);
        }
        [Test]
        public void Add_InvalidRequest_ShouldThrowHttpStatusCodeException()
        {
            // Arrange
            CreateStudentRequestModel request = null;

            // Act & Assert
            var ex = Assert.Throws<HttpStatusCodeException>(() => _studentService.Add(request));
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.Message, Is.EqualTo(nameof(Student)));
        }
    }
}
