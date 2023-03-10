using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class ChapterService : BaseService<Chapter>
    {
        public ChapterService(IBaseRepository<Chapter> repository) : base(repository)
        {
        }
    }
}
