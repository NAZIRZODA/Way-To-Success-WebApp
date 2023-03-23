using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.RequestModels.CourseRequestModels
{
    public class CourseRequestModel : BaseRequestModel
    {
        public ulong Id { get; set; }
        public string Name{ get; set; }
    }
}
