using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.StudentAnswerRequests;
using WTSuccess.Domain.Models.ExamScene;
using WTSuccess.Infrastructure.Persistence.DataBases;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public class StudentAnswerRepository : Repository<StudentAnswer>, IStudentAnswerRepository
    {
        private readonly DbSet<StudentAnswer> _dbStudentAnswer;
        private readonly EFContext _context;
        public StudentAnswerRepository(EFContext context) : base(context)
        {
            _dbStudentAnswer = context.Set<StudentAnswer>();
            _context = context;
        }

        //public bool CheckForDuplicateAnswers(CreateStudentAnswerRequestModel createStudentAnswerRequestModel)
        //{
        //    var result = _dbStudentAnswer.FirstOrDefault(i => i.AnswerId == createStudentAnswerRequestModel.AnswerId
        //    && i.StudenExamId == createStudentAnswerRequestModel.StudenExamId
        //    && i.QuestionId == createStudentAnswerRequestModel.QuestionId);

        //    if (result == null || System.DBNull.Value==null) return false;

        //    return true;
        //}
    }
}
