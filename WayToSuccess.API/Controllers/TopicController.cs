using Microsoft.AspNetCore.Mvc;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Requests.TopicRequests;
using WTSuccess.Application.Responses.TopicResponses;

namespace WTSuccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpPost]
        public void Add(CreateTopicRequestModel topic)
        {
            _topicService.Add(topic);
        }

        [HttpPut("{id}")]
        public void Update(ulong id, TopicRequestModel topic)
        {
            _topicService.Update(id, topic);
        }

        [HttpDelete("{id}")]
        public void DeleteById(ulong id)
        {
            _topicService.Delete(id);
        }

        [HttpGet("{id}")]
        public TopicResponseModel GetById(ulong id)
        {
            return _topicService.Get(id);
        }

        [HttpGet("GetAll")]
        public IEnumerable<TopicResponseModel> GetAll(int pageList, int pageNumber)
        {
            return _topicService.GetAll(pageList, pageNumber);
        }
    }
}
