using Microsoft.AspNetCore.Mvc;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Requests.GameQuestionRequests;
using WTSuccess.Application.Responses.GameQuestionResponses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WayToSuccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameQuestionController : ControllerBase
    {

        private readonly IGameQuestionService _gameQuestionService;

        public GameQuestionController(IGameQuestionService gameQuestionService)
        {
            _gameQuestionService = gameQuestionService;
        }

        [HttpGet]
        public IEnumerable<GameQuestionResponseModel> Get(int pageList, int pageNumber)
        {
            return _gameQuestionService.GetAll(pageList, pageNumber);
        }


        [HttpGet("{id}")]
        public GameQuestionResponseModel Get(ulong id)
        {
            return _gameQuestionService.Get(id);
        }


        [HttpPost]
        public void Post([FromBody] CreateGameQuestionRequestModel questionRequest)
        {
            _gameQuestionService.Add(questionRequest);
        }


        [HttpPut("{id}")]
        public void Put(ulong id, [FromBody] UpdateGameQuestionRequestModel questionRequest)
        {
            _gameQuestionService.Update(id, questionRequest);
        }


        [HttpDelete("{id}")]
        public void Delete(ulong id)
        {
            _gameQuestionService.Delete(id);
        }
    }
}
