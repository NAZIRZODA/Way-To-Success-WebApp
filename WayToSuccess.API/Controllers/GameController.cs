using Microsoft.AspNetCore.Mvc;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Requests.GameRequests;
using WTSuccess.Application.Responses.GameResponses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WayToSuccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IEnumerable<GameResponseModel> Get(int pageList, int pageNumber)
        {
            return _gameService.GetAll(pageList, pageNumber);
        }

        [HttpGet("{id}")]
        public GameResponseModel Get(ulong id)
        {
            return _gameService.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] CreateGameRequestModel gameRequest)
        {
            _gameService.Add(gameRequest);
        }

        [HttpPut("{id}")]
        public void Put(ulong id, [FromBody] UpdateGameRequestModel gameRequest)
        {
            _gameService.Update(id, gameRequest);
        }

        [HttpDelete("{id}")]
        public void Delete(ulong id)
        {
            _gameService.Delete(id);
        }
    }
}
