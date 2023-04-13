using WTSuccess.Application.Requests.StudentRequests;
using WTSuccess.Application.Responses.StudentRespones;
using WTSuccess.Domain.Models;
namespace WTSuccess.Application.Common.Interfaces
{
    public interface IStudentService : IBaseService<Student, StudentResponseModel, StudentRequestModel>
    {
        public void AddCourse(ulong courseId, ulong studentId);
    }
}
