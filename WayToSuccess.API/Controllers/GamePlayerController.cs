using Microsoft.AspNetCore.Mvc;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Requests.GamePlayerRequest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WayToSuccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamePlayerController : ControllerBase
    {
        private readonly IGamePlayerService _gamePlayerService;

        public GamePlayerController(IGamePlayerService gamePlayerService)
        {
            _gamePlayerService = gamePlayerService;
        }

        [HttpPost]
        public void Post([FromBody] CreateGamePlayerRequestModel playerRequest)
        {
            _gamePlayerService.Add(playerRequest);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
