using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.ResponseModels.CourseResponseModels
{
    public class CourseResponseModel:BaseResponseModel
    {
        public string Name { get; set; }
    }
}
