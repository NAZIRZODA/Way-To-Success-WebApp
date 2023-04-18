using Microsoft.AspNetCore.Mvc;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Requests.StudentAnswerRequests;
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


        // POST api/<StudentExamController>
        [HttpPost]
        public void Post([FromBody] CreateStudentExamRequestModel studentExamRequest)
        {
            _studentExamService.Add(studentExamRequest);
        }
    }
}
