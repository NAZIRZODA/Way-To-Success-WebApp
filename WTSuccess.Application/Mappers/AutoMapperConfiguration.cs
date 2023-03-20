using AutoMapper;
using WTSuccess.Application.RequestModels.StudentRequestModels;
using WTSuccess.Application.ResponseModels.CourseResponseModels;
using WTSuccess.Application.ResponseModels.StudentResponseModels.cs;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Mappers;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<Student, StudentResponseModel>()
            .ForMember(des => des.LastName, src => src.MapFrom(s => $"{s.Surname}jon"));

        CreateMap<CreateStudentRequestModel, Student>()
            .ForMember(s => s.Surname, src => src.MapFrom(r => r.LastName));

        CreateMap<UpdateStudentRequestModel, Student>()
            .ForMember(s => s.Surname, src => src.MapFrom(r => r.LastName));

        CreateMap<Course, CourseResponseModel>();
        CreateMap<CreateStudentRequestModel, Course>();
        CreateMap<UpdateStudentRequestModel, Course>();
    }
}