using AutoMapper;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.RequestModels.StudentRequestModels;
using WTSuccess.Application.ResponseModels.StudentResponseModels.cs;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class StudentService : BaseService<Student, StudentResponseModel, StudentRequestModel>, IStudentService
    {
        public StudentService(IStudentRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override StudentResponseModel GetById(ulong id)
        {
            return Mapper.Map<Student, StudentResponseModel>(new Student(){Name = "Ali", Surname = "Vali"});
        }
    }
}
