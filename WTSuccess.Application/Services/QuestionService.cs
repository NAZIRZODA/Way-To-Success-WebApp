
using AutoMapper;
using System.Net;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.Question;
using WTSuccess.Application.Responses.QuestionResponses;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class QuestionService : BaseService<Question, QuestionResponseModel, QuestionRequestModel>, IQuestionService
    {
        private readonly IChapterRepository _chapterRepository;
        public QuestionService(IQuestionRepository questionRepository,  IMapper mapper, IChapterRepository chapterRepository) : base(questionRepository, mapper)
        {
            _chapterRepository = chapterRepository;
        }

        public override QuestionResponseModel Add(QuestionRequestModel request)
        {
            var createQuestionRequestModel = request as CreateQuestionRequestModel;
            if (createQuestionRequestModel == null) 
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Couldn't cast request to create question request");

            var chapter = _chapterRepository.FindById(createQuestionRequestModel.ChapterId);
            if (chapter == null) 
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Chapter with id: {createQuestionRequestModel.ChapterId} not found");

            if (createQuestionRequestModel.Answers.Count == 0 || createQuestionRequestModel.Answers.FirstOrDefault(a => a.isCorrect) == null)
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Question should have even 1 correct answer");
            return base.Add(request); 
        }

        public override QuestionResponseModel Update(ulong id, QuestionRequestModel request)
        {
            var chapter = _chapterRepository.FindById(request.ChapterId);
            if (chapter == null)
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Chapter with id: {request.ChapterId} not found");

            return base.Update(id, request);
        }

        public override IEnumerable<QuestionResponseModel> GetAll(int pageList, int pageNumber)
        {
            return base.GetAll(pageList, pageNumber);
        }
    }
}
