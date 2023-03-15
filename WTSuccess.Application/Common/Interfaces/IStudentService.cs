using WTSuccess.Application.RequestModels.StudentRequestModels;
using WTSuccess.Application.ResponseModels.StudentResponseModels.cs;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface IStudentService : IBaseService<Student, StudentResponseModel, StudentRequestModel>
    {
    }
}