using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models.CourseScene;

namespace WTSuccess.Application.Requests.ChapterRequests
{
    public class UpdateChapterRequestModel : ChapterRequestModel
    {
        public List<Topic> Topics { get; set; }
        public Course Course { get; set; }
        public ulong CourseId { get; set; }
    }
}
