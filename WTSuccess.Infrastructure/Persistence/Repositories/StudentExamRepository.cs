﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Domain.Models;
using WTSuccess.Infrastructure.Persistence.DataBases;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public class StudentExamRepository : Repository<StudentExam>, IStudentExamRepository
    {
        private readonly DbSet<Chapter> _dbStudentExam;
        private readonly EFContext _context;
        public StudentExamRepository(EFContext context) : base(context)
        {
            _dbStudentExam = context.Set<Chapter>();
            _context = context;
        }
    }
}