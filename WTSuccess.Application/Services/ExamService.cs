using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.ExamRequests;
using WTSuccess.Application.Responses.ExamRespones;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class ExamService : BaseService<Exam, ExamResponseModel, ExamRequestModel>, IExamService
    {
        public ExamService(IRepository<Exam> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
