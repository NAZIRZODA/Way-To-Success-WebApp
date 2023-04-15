using AutoMapper;
using Moq;
using NUnit.Framework;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.StudentRequests;
using WTSuccess.Application.Responses.StudentRespones;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Tests.ServicesTest.StudentServiceTest
{
    [TestFixture]
    public class UpdateStudentServiceTest
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
        public void UpdateStudent_WithValidIdAndRequest_ReturnsStudentResponseModel()
        {
            ulong id = 1;
            var request = new UpdateStudentRequestModel { Name = "John", Surname = "Doe", Email = "Johndoe@gmail.com", Password = "211324", Gender = true };
            var dbStudent = new Student { Id = id, Name = "Original Title" };
            var expectedResponse = new StudentResponseModel { Id = id, Name = "John", Surname = "Doe", Email = "Johndoe@gmail.com", Password = "211324" };
            var mockRepository = new Mock<IStudentRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockCourseRepository = new Mock<ICourseRepository>();
            mockRepository.Setup(x => x.FindById(id)).Returns(dbStudent);
            mockMapper.Setup(x => x.Map<UpdateStudentRequestModel, Student>(request, dbStudent))
                .Returns(dbStudent);
            mockMapper.Setup(x => x.Map<Student, StudentResponseModel>(dbStudent))
                .Returns(expectedResponse);
            _studentService = new StudentService(mockRepository.Object, mockCourseRepository.Object, mockMapper.Object);
            var response = _studentService.Update(id, request);
            Assert.AreEqual(expectedResponse.Id, response.Id);
            Assert.AreEqual(expectedResponse.Name, response.Name);
            Assert.AreEqual(expectedResponse.Surname, response.Surname);
            Assert.AreEqual(expectedResponse.Email, response.Email);
            Assert.AreEqual(expectedResponse.Password, response.Password);
        }
    }
}
