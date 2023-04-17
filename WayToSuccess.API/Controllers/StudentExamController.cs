using Microsoft.AspNetCore.Mvc;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Requests.StudentExamRequests;
using WTSuccess.Application.Responses.QuestionResponses;
using WTSuccess.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WayToSuccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamController : ControllerBase
    {
        private readonly IStudentExamService _studentExamService;

        public StudentExamController(IStudentExamService studentExamService)
        {
            _studentExamService = studentExamService;
        }
        // GET: api/<StudentExamController>
        [HttpGet("GetQuestions")]
        public IEnumerable<QuestionResponseModel> Get(ulong studentExamId)
        {
            return _studentExamService.GetQuestions(studentExamId);
        }

        // GET api/<StudentExamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentExamController>
        [HttpPost]
        public void Post([FromBody] CreateStudentExamRequestModel studentExamRequest)
        {
            _studentExamService.Add(studentExamRequest);
        }

        // PUT api/<StudentExamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentExamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
