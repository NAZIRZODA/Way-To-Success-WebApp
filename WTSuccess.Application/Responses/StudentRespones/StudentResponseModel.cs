using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Responses.CourseRespnses;
using WTSuccess.Domain.Models.CourseScene;

namespace WTSuccess.Application.Responses.StudentRespones
{
    public class StudentResponseModel : BaseResponse
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<CourseResponseModel> Courses { get; set; }
        public string Password { get; set; }
    }
}
