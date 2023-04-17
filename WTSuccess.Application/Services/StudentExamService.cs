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
using WTSuccess.Application.Requests.StudentExamRequests;
using WTSuccess.Application.Responses.QuestionResponses;
using WTSuccess.Application.Responses.StudentExamRespones;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class StudentExamService : BaseService<StudentExam, StudentExamResponseModel, StudentExamRequestModel>, IStudentExamService
    {
        private readonly IStudentExamRepository _studentExamRepository;
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;

        public StudentExamService(IStudentExamRepository repository, IMapper mapper, IQuestionRepository questionRepository) : base(repository, mapper)
        {
            _studentExamRepository = repository;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }

        public override void Add(StudentExamRequestModel request)
        {
            var entity = request as CreateStudentExamRequestModel;
            if (entity == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(StudentExam));
            var studentExam = _mapper.Map<CreateStudentExamRequestModel, StudentExam>(entity);
            _studentExamRepository.Add(studentExam);
            _studentExamRepository.SaveChanges();
        }


        //from IStudentExamService
        public IEnumerable<QuestionResponseModel> GetQuestions(ulong studentExamId)
        {
            var studentExam = _studentExamRepository.FindById(studentExamId);
            if (studentExam == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);
            var questions= studentExam.Chapter.Questions;
            var mappedToRespone = _mapper.Map<IEnumerable<Question>,IEnumerable<QuestionResponseModel>>(questions);
            return mappedToRespone;
        }
    }
}
