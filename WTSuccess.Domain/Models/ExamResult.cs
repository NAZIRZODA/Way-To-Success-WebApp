using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models
{
    public class ExamResult: EntityBase
    {
        public virtual StudentExam StudentExam { get; set; }

        public ulong StudenExamId { get; set; }

        public ulong AnswerId { get; set; }

        public bool IsTrue { get; set; }
    }
}
