
using AutoMapper;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.Question;
using WTSuccess.Application.Responses.QuestionResponses;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class QuestionService : BaseService<Question, QuestionResponseModel, QuestionRequestModel>, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public QuestionService(IQuestionRepository questionRepository, IMapper mapper) : base(questionRepository, mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public override void Add(QuestionRequestModel request)
        {
            var createQuestionRequestModel = request as CreateQuestionRequestModel;
            var question = _mapper.Map<CreateQuestionRequestModel, Question>(createQuestionRequestModel);
            _questionRepository.Add(question);
            _questionRepository.SaveChanges();
        }

        public override QuestionResponseModel Update(ulong id, QuestionRequestModel request)
        {
            return base.Update(id, request);
        }

        public override QuestionResponseModel Get(ulong id)
        {
            return base.Get(id);
        }

        public override IEnumerable<QuestionResponseModel> GetAll(int pageList, int pageNumber)
        {
            return base.GetAll(pageList, pageNumber);
        }

        public override bool Delete(ulong id)
        {
            return base.Delete(id);
        }
    }
}
