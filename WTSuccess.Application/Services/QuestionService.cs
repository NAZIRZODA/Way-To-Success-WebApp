
using AutoMapper;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.Question;
using WTSuccess.Application.Responses.QuestionResponses;
using WTSuccess.Domain.Models.ExamScene;

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
            var entity = _questionRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);
            var questionRequestToUpdate = request as UpdateQuestionRequestModel;
            var result = _mapper.Map(questionRequestToUpdate, entity);
            _questionRepository.Update(result);
            _questionRepository.SaveChanges();
            return _mapper.Map<Question, QuestionResponseModel>(result);
        }

        public override QuestionResponseModel Get(ulong id)
        {
            var entity = _questionRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);
            var mapped = _mapper.Map<Question, QuestionResponseModel>(entity);
            return mapped;
        }

        public override IEnumerable<QuestionResponseModel> GetAll(int pageList, int pageNumber)
        {
            var entities = _questionRepository.GetAll(pageList, pageNumber);
            if (entities == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);
            var mappedEntities = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionResponseModel>>(entities);
            return mappedEntities;
        }

        public override bool Delete(ulong id)
        {
            var entity = _questionRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);
            _questionRepository.Delete(entity);
            _questionRepository.SaveChanges();
            return true;
        }
    }
}
