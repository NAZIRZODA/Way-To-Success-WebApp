
using Microsoft.EntityFrameworkCore;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Domain.Models.ExamScene;
using WTSuccess.Infrastructure.Persistence.DataBases;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly DbSet<Question> _dbQuestion;
        private readonly EFContext _eFContext;
        public QuestionRepository(EFContext context) : base(context)
        {
            _dbQuestion = context.Set<Question>();
            _eFContext = context;
        }
    }
}
