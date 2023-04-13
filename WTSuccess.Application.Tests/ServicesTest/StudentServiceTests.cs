using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Net;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Requests.StudentRequests;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Application.Responses.StudentRespones;
using WTSuccess.Application.Services;
using WTSuccess.Domain.Models;

[TestFixture]
public class StudentServiceTests
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
        var service = new StudentService( mockStudentRepository.Object, mockCourseRepository.Object, mockMapper.Object);

        // Act
        service.Add(request);

        // Assert
        mockMapper.Verify(m => m.Map<CreateStudentRequestModel, Student>(request), Times.Once);
        mockStudentRepository.Verify(m => m.Add(It.IsAny<Student>()), Times.Once);
        mockStudentRepository.Verify(m => m.SaveChanges(), Times.Once);
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
