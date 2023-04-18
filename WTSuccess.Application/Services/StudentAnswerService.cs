using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.StudentAnswerRequests;
using WTSuccess.Application.Responses.StudentAnswerResponses;
using WTSuccess.Application.Responses.StudentExamRespones;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class StudentAnswerService : BaseService<StudentAnswer, StudentAnswerResponseModel, StudentAnswerRequestModel>, IStudentAnswerService
    {
        private readonly IStudentAnswerRepository _studentAnswerRepository;
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;

        public StudentAnswerService(IStudentAnswerRepository repository, IMapper mapper, IAnswerRepository answerRepository) : base(repository, mapper)
        {
            _studentAnswerRepository = repository;
            _mapper = mapper;
            _answerRepository = answerRepository;
        }

        public override void Add(StudentAnswerRequestModel request)
        {
            var entity = request as CreateStudentAnswerRequestModel;

            if (ControlOfRepeatAnswerWithQuestion(entity)) throw new Exception("Already you answered this q");

            var mappedToStudentAnswer = _mapper.Map<CreateStudentAnswerRequestModel, StudentAnswer>(entity);
            if (TestIsChecked(entity.AnswerId)) mappedToStudentAnswer.IsTrue = true;

            _studentAnswerRepository.Add(mappedToStudentAnswer);
            _studentAnswerRepository.SaveChanges();
        }

        //this method checks Answer of test.
        public bool TestIsChecked(ulong answerId)
        {
            var answer = _answerRepository.FindById(answerId);
            if (answer == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            if (answer.isCorrect) return true;

            return false;
        }

        public bool ControlOfRepeatAnswerWithQuestion(CreateStudentAnswerRequestModel createStudentAnswerRequestModel)
        {
            return _studentAnswerRepository.CheckForDuplicateAnswers(createStudentAnswerRequestModel);
        }

    }
}
