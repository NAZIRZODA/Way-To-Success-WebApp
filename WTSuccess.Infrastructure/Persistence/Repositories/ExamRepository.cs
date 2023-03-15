// using Microsoft.EntityFrameworkCore;
// using WTSuccess.Application.Common.Interfaces.Repositories;
// using WTSuccess.Application.Context;
// using WTSuccess.Domain.Models;
//
// namespace WTSuccess.Infrastructure.Persistence.Repositories
// {
//     public class ExamRepository : BaseRepository<Exam>, IExamRepository
//     {
//         private readonly WTSuccessContext _context;
//         private readonly DbSet<Exam> _examSet;
//         public ExamRepository(WTSuccessContext dbcontext)
//         {
//             _examSet = dbcontext.Set<Exam>();
//             _context = dbcontext;
//         }
//
//         public override void Add(Exam entity)
//         {
//             _examSet.Add(entity);
//         }
//
//         public override void Update(Exam entity, ulong id)
//         {
//             var dbValue = _examSet.Find(id);
//             if (dbValue != null)
//             {
//                 dbValue.ExamResult = entity.ExamResult;
//                 dbValue.Questions=entity.Questions;
//                 dbValue.StudentId = entity.StudentId;
//                 _examSet.Update(dbValue);
//             }
//         }
//     }
// }
