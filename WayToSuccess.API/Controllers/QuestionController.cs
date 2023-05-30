using Microsoft.AspNetCore.Mvc;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Requests.Question;
using WTSuccess.Application.Responses.QuestionResponses;

namespace WayToSuccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("id")]
        public QuestionResponseModel Get(ulong id)
        {
            return _questionService.Get(id);
        }

        [HttpPost]
        public void Add(CreateQuestionRequestModel questionRequestModel)
        {
            _questionService.Add(questionRequestModel);
        }

        [HttpPut("id")]
        public void Update(ulong id, UpdateQuestionRequestModel questionRequestModel)
        {
            _questionService.Update(id, questionRequestModel);
        }

        [HttpDelete("id")]
        public void Delete(ulong id)
        {
            _questionService.Delete(id);
        }
    }
}
