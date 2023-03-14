using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class CodeChallengeService : BaseService<CodeChallenge>
    {
        
        public CodeChallengeService(IBaseRepository<CodeChallenge> repository) : base(repository)
        {
        }
    }
}
