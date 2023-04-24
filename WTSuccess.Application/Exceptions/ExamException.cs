using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Application.Exceptions
{
    public class ExamException : Exception
    {
        public ExamExceptionStatus ExamExceptionStatus { get; set; }
        public ExamException(ExamExceptionStatus examExceptionStatus)
        {
            ExamExceptionStatus = examExceptionStatus;
        }

        public ExamException(ExamExceptionStatus examExceptionStatus ,string? message) : base(message)
        {
            ExamExceptionStatus= examExceptionStatus;
        }

        public ExamException(ExamExceptionStatus examMessage, Exception innerException) : this(examMessage, innerException.ToString())
        {
        }

        protected ExamException(ExamExceptionStatus examMessage, JObject errorObject) : this(examMessage, errorObject.ToString())
        {
        }
    }

    public enum ExamExceptionStatus
    {
        NotAnswered = 0,
    }
}
