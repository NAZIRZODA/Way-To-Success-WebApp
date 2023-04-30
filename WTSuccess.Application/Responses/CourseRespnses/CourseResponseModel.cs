using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.ChapterRequests;
using WTSuccess.Application.Responses.ChapterRespones;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Responses.CourseRespnses
{
    public class CourseResponseModel : BaseResponse
    {
        public string Name { get; set; }
        public List<ChapterResponseModel> Chapters { get; set; }
        //public List<Student> Students { get; set; }
    }
}
