

using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Net;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Responses.StudentRespones;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.StudentServiceTest
{
    [TestFixture]
    internal class GetStudentServiceTest
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
        public void Get_ExistingStudentId_ShouldReturnChapterResponseModel()
        {
            // Arrange
            ulong studentId = 1;
            ulong courseId = 2;
            var student = new Student { Id = studentId, Name = "John", Surname = "Doe", Email = "Johndoe@gmail.com", Password = "211324", Gender = true };
            _mockStudentRepository.Setup(x => x.FindById(studentId)).Returns(student);
            _mockMapper.Setup(m => m.Map<Student, StudentResponseModel>(student))
                .Returns(new StudentResponseModel() { Name = "John", Surname = "Doe", Email = "Johndoe@gmail.com", Password = "211324" });

            var mockCourseRepository = new Mock<ICourseRepository>();
            var studentService = new StudentService(_mockStudentRepository.Object, mockCourseRepository.Object, _mockMapper.Object);
            // Act

            StudentResponseModel result = studentService.Get(studentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(student.Name));
            Assert.That(result.Surname, Is.EqualTo(student.Surname));
            Assert.That(result.Email, Is.EqualTo(student.Email));
            Assert.That(result.Password, Is.EqualTo(student.Password));
        }

        [Test]
        public void Get_NonExistingStudentId_ShouldThrowHttpStatusCodeException()
        {
            // Arrange
            ulong studentId = 1;
            _mockStudentRepository.Setup(x => x.FindById(studentId)).Returns((Student)null);

            // Act & Assert
            var ex = Assert.Throws<HttpStatusCodeException>(() => _studentService.Get(studentId));
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.Message, Is.EqualTo(nameof(Student)));
        }
    }
}
