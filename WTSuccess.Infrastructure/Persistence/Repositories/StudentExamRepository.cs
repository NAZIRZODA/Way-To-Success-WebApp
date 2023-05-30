using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.StudentAnswerRequests;
using WTSuccess.Domain.Models.ExamScene;
using WTSuccess.Infrastructure.Persistence.DataBases;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public class StudentExamRepository : Repository<StudentExam>, IStudentExamRepository
    {
        private readonly DbSet<StudentExam> _dbStudentExam;
        private readonly EFContext _contextAnswer;

        private IEnumerable<Question> _question;

        public StudentExamRepository(EFContext context, EFContext contextAnswer) : base(context)
        {
            _dbStudentAnswer = contextAnswer.Set<StudentAnswer>();
            _contextAnswer = contextAnswer;
            _dbStudentExam = context.Set<StudentExam>();
            _context = context;
        }
        public override StudentExam FindById(ulong id)
        {
            var studentExam = _dbStudentExam.Find(id);
            if (studentExam == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);
            return studentExam;
        }
        public string AddExamAnswers(List<StudentAnswer>
            createStudentAnswerRequestModels)
        {
            _question = _dbStudentExam
                .Find(createStudentAnswerRequestModels[0].StudenExamId)
                .Chapter.Questions;
            if (createStudentAnswerRequestModels.Count() != _question.Count()) throw new ExamException(ExamExceptionStatus.NotAnswered);
            var studentAnswers = CheckAnswers(createStudentAnswerRequestModels);
            _contextAnswer.AddRange(studentAnswers);
            _contextAnswer.SaveChanges();
            return $"you answered :{ResultOfExam(studentAnswers)} from {studentAnswers.Count()}";
        }

        public List<StudentAnswer> CheckAnswers(List<StudentAnswer>
            createStudentAnswerRequestModels)
        {
            var studentAnswers = new List<StudentAnswer>();
            var question = new Question();
            foreach (var studentAnswerItem in createStudentAnswerRequestModels)
            {
                question = _question
                    .FirstOrDefault(i => i.Id == studentAnswerItem.QuestionId);
                var answer = question
                    .Answers.FirstOrDefault(id => id.Id == studentAnswerItem.AnswerId);
                studentAnswerItem
                    .IsTrue = answer.isCorrect;
                studentAnswers.Add(studentAnswerItem);
            }
            return studentAnswers;
        }

        public string ResultOfExam(List<StudentAnswer>
            createStudentAnswerRequestModels)
        {
            int numberOfTrueAnswers = 0;
            foreach (var studentItemAnswer in createStudentAnswerRequestModels)
            {
                if (studentItemAnswer.IsTrue == true) numberOfTrueAnswers++;
            }
            return numberOfTrueAnswers.ToString();
        }
    }
}
