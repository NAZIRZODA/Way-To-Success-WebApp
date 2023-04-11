using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Requests.CourseRequests;
using WTSuccess.Application.Requests.StudentRequests;
using WTSuccess.Application.Requests.TopicRequests;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Application.Responses.CourseRespnses;
using WTSuccess.Application.Responses.StudentRespones;
using WTSuccess.Application.Responses.TopicResponses;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Mappers
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<StudentRequestModel, Student>();
            CreateMap<Student, StudentResponseModel>();
            CreateMap<UpdateStudentRequestModel, Student>();

            CreateMap<CourseRequestModel, Exam>();
            CreateMap<Exam, CourseResponseModel>();
            CreateMap<UpdateCourseRequestModel, Exam>();

            CreateMap<ChapterRequestModel, Chapter>();
            CreateMap<Chapter, ChapterResponseModel>();
            CreateMap<UpdateChapterRequestModel, Chapter>();

            CreateMap<TopicRequestModel, Topic>();
            CreateMap<Topic, TopicResponseModel>();
            CreateMap<UpdateTopicRequestModel, Topic>();
        }
    }
}
