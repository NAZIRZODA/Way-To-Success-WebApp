using WTSuccess.Application.RequestModels.CourseRequestModels;
using WTSuccess.Application.ResponseModels.CourseResponseModels;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface ICourseService : IBaseService<Course, CourseResponseModel, CourseRequestModel>
    {
    }
}
