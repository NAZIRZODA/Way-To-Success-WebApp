using AutoMapper;
using Moq;
using NUnit.Framework;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Services;

namespace WTSuccess.Application.Tests.ServicesTest.StudentServiceTest
{
    [TestFixture]
    public class GetAllStudentServiceTest
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

        //[Test]
        //public void GetAll_ValidPageListAndPageNumber_ReturnsStudentResponseModels()
        //{
        //    // Arrange
        //    var pageList = 10;
        //    var pageNumber = 1;
        //    var students = new List<Student>
        //{
        //    new Student { Id = 1UL, Name = "John", Surname = "Doe", Email = "Johndoe@gmail.com", Password = "211324", Gender = true  },
        //    new Student { Id = 2UL, Name = "John", Surname = "Doe", Email = "Johndoe@gmail.com", Password = "211324", Gender = true  }
        //};
        //    var mockMapper = new Mock<IMapper>();
        //    var mockStudentRepository = new Mock<IStudentRepository>();
        //    var mockCourseRepository = new Mock<ICourseRepository>();
        //    mockStudentRepository.Setup(m => m.GetAll(pageList, pageNumber)).Returns(students.AsQueryable());
        //    var service = new StudentService( mockStudentRepository.Object, mockCourseRepository.Object, mockMapper.Object);

        //    // Act
        //    var result = service.GetAll(pageList, pageNumber);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsInstanceOf<IEnumerable<StudentResponseModel>>(result);
        //    Assert.AreEqual(students.Count, result.Count());
        //    foreach (var student in students)
        //    {
        //        var studentResponse = result.FirstOrDefault(s => s.Id == student.Id);
        //        Assert.IsNotNull(studentResponse);
        //        Assert.AreEqual(student.Name, studentResponse.Name);
        //        Assert.AreEqual(student.Surname, studentResponse.Surname);
        //        Assert.AreEqual(student.Email, studentResponse.Email);
        //        Assert.AreEqual(student.Password, studentResponse.Password);
        //    }
        //    mockMapper.Verify(m => m.Map<IEnumerable<Student>, IEnumerable<StudentResponseModel>>(students), Times.Once);
        //    mockStudentRepository.Verify(m => m.GetAll(pageList, pageNumber), Times.Once);
        //}

        //[Test]
        //public void GetAll_ReturnsCorrectNumberOfStudentsOnPage()
        //{
        //    // Arrange
        //    var expectedStudents = new List<Student>()
        //{
        //     new Student { Id = 1, Name = "John", Email = "johndoe@gmail.com", Surname = "Doe", Password="123456", Gender = true},
        //    new Student { Id = 2, Name = "Jane", Email = "janesmith@gmail.com", Surname = "Smith", Password = "321654", Gender = true },
        //    new Student { Id = 3, Name = "Bob", Email = "bobjohnson@gmail.com", Surname = "Johnson", Password = "654321", Gender = true},
        //};
        //    var pageSize = 2;
        //    var pageNumber = 2;
        //    var mockCourseRepository = new Mock<ICourseRepository>();
        //    _mockStudentRepository.Setup(x => x.GetAll(pageSize, pageNumber)).Returns(expectedStudents.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsQueryable());
        //    var studentService = new StudentService(_mockStudentRepository.Object, mockCourseRepository.Object, _mockMapper.Object);

        //    // Act
        //    var actualResponseModels = studentService.GetAll(pageSize, pageNumber);

        //    // Assert
        //    Assert.That(actualResponseModels.Count(), Is.EqualTo(pageSize));
        //}
    }
}
