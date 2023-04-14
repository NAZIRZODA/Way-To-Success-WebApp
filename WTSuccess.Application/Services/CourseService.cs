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
using WTSuccess.Application.Requests.CourseRequests;
using WTSuccess.Application.Requests.StudentRequests;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Application.Responses.CourseRespnses;
using WTSuccess.Application.Responses.StudentRespones;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class CourseService : BaseService<Course, CourseResponseModel, CourseRequestModel>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _courseRepository = repository;
            _mapper = mapper;
        }

        public override CourseResponseModel Add(CourseRequestModel request)
        {
            var parsedToCreate = request as CreateCourseRequestModel;
            if (parsedToCreate == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));
            return base.Add(request);
        }

        public override CourseResponseModel Get(ulong id)
        {
            var dbChapter = _courseRepository.FindById(id);
            if (dbChapter == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));

            var mappedToResponse = _mapper.Map<Course, CourseResponseModel>(dbChapter);
            return mappedToResponse;
        }

        public override IEnumerable<CourseResponseModel> GetAll(int pageList, int pageNumber)
        {
            var dbCourse = _courseRepository.GetAll(pageList, pageNumber);
            var mappedToRespones = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseResponseModel>>(dbCourse);
            return mappedToRespones;
        }

        public override CourseResponseModel Update(ulong id, CourseRequestModel request)
        {
            var dbCourse = _courseRepository.FindById(id);
            if (dbCourse == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));
            var courseRequestToUpdate = request as UpdateCourseRequestModel;
            var result = _mapper.Map(courseRequestToUpdate, dbCourse);
            _courseRepository.Update(dbCourse);
            _courseRepository.SaveChanges();
            return _mapper.Map<Course, CourseResponseModel>(dbCourse);
        }

        public override bool Delete(ulong id)
        {
            var dbCourse = _courseRepository.FindById(id);
            if (dbCourse == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));
            _courseRepository.Delete(dbCourse);
            _courseRepository.SaveChanges();
            return true;
        }
    }
}