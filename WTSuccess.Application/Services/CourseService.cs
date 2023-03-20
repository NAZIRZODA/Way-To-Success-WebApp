using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.RequestModels.CourseRequestModels;
using WTSuccess.Application.ResponseModels.CourseResponseModels;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class CourseService : BaseService<Course, CourseResponseModel, CourseRequestModel>, ICourseService
    {
        public CourseService(IBaseRepository<Course> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
