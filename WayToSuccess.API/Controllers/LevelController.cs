using Microsoft.AspNetCore.Mvc;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Requests.LevelRequests;
using WTSuccess.Application.Responses.LevelResponses;

namespace WayToSuccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpGet]
        public IEnumerable<LevelResponseModel> Get(int pageList, int pageNumber)
        {
            return _levelService.GetAll(pageList, pageNumber);
        }

        [HttpGet("{id}")]
        public LevelResponseModel Get(ulong id)
        {
            return _levelService.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] CreateLevelRequestModel levelRequest)
        {
            _levelService.Add(levelRequest);
        }

        [HttpPut("{id}")]
        public void Put(ulong id, [FromBody] UpdateLevelRequestModel levelRequest)
        {
            _levelService.Update(id, levelRequest);
        }

        [HttpDelete("{id}")]
        public void Delete(ulong id)
        {
            _levelService.Delete(id);
        }
    }
}
