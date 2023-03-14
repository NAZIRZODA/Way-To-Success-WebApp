using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models
{
    public class Question : EntityBase
    {
        Dictionary<string, string> QuestionsAnswer { get; set; }
        public ulong ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
