using AutoMapper;
using Moq;
using NUnit.Framework;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.StudentServiceTest
{
    [TestFixture]
    public class DeleteStudentServiceTest
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
        public void Delete_StudentExists_ShouldDeleteAndReturnTrue()
        {
            // Arrange
            ulong id = 1;
            var dbStudent = new Student { Id = id, Name = "Chapter to delete" };
            _mockStudentRepository.Setup(x => x.FindById(id)).Returns(dbStudent);
            // Act
            var result = _studentService.Delete(id);

            // Assert
            Assert.IsTrue(result);
            _mockStudentRepository.Verify(x => x.Delete(dbStudent), Times.Once);
            _mockStudentRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void Delete_StudentDoesNotExist_ShouldThrowHttpStatusCodeException()
        {
            // Arrange
            ulong id = 1;
            _mockStudentRepository.Setup(x => x.FindById(id)).Returns((Student)null);
            // Act & Assert
            Assert.Throws<HttpStatusCodeException>(() => _studentService.Delete(id));
            _mockStudentRepository.Verify(x => x.Delete(It.IsAny<Student>()), Times.Never);
            _mockStudentRepository.Verify(x => x.SaveChanges(), Times.Never);
        }
    }
}
