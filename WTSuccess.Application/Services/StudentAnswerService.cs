using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.StudentAnswerRequests;
using WTSuccess.Application.Responses.StudentAnswerResponses;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class StudentAnswerService : BaseService<StudentAnswer, StudentAnswerResponseModel, StudentAnswerRequestModel>
    {
        private readonly IStudentAnswerRepository _studentAnswerRepository;
        private readonly IMapper _mapper;

        public StudentAnswerService(IStudentAnswerRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _studentAnswerRepository = repository;
            _mapper = mapper;
        }

        public override void Add(StudentAnswerRequestModel request)
        {

        }

    }
}
