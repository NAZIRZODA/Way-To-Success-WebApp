using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests;
using WTSuccess.Application.Requests.StudentRequests;
using WTSuccess.Application.Responses.StudentRespones;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class StudentService : BaseService<Student, StudentResponseModel, StudentRequestModel>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository repository, ICourseRepository courseRepository, IMapper mapper) : base(repository, mapper)
        {
            _studentRepository = repository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public override void Add(StudentRequestModel request)
        {
            var parsedToCreate = request as CreateStudentRequestModel;
            if (parsedToCreate == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));

            var mappedToStudent = _mapper.Map<CreateStudentRequestModel, Student>(parsedToCreate);
            _studentRepository.Add(mappedToStudent);
            _studentRepository.SaveChanges();
        }

        public override StudentResponseModel Get(ulong id)
        {
            var dbStudent = _studentRepository.FindById(id);
            if (dbStudent == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));

            var mappedToResponse = _mapper.Map<Student, StudentResponseModel>(dbStudent);
            return mappedToResponse;
        }

        public override IEnumerable<StudentResponseModel> GetAll(int pageList, int pageNumber)
        {
            var dbStudents = _studentRepository.GetAll(pageList, pageNumber);
            var mappedToRespones = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResponseModel>>(dbStudents);
            return mappedToRespones;
        }

        public override StudentResponseModel Update(ulong id, StudentRequestModel request)
        {
            var entity = _studentRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));

            var studentRequestToUpdate = request as UpdateStudentRequestModel;
            var result = _mapper.Map(studentRequestToUpdate, entity);
            _studentRepository.Update(entity);
            _studentRepository.SaveChanges();
            return _mapper.Map<Student, StudentResponseModel>(entity);
        }

        public override bool Delete(ulong id)
        {
            var dbStudent = _studentRepository.FindById(id);
            if (dbStudent == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));

            _studentRepository.Delete(dbStudent);
            _studentRepository.SaveChanges();
            return true;
        }

        public void AddCourse(ulong courseId, ulong studentId)
        {
            var course = _courseRepository.FindById(courseId);
            if (course == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));

            var student = _studentRepository.FindById(studentId);
            if (student == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));

            student.Courses.Add(course);
            _studentRepository.SaveChanges();
        }
    }
}
