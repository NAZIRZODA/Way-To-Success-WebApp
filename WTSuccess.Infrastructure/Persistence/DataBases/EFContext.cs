﻿using Microsoft.EntityFrameworkCore;
using WTSuccess.Domain.Models;

namespace WTSuccess.Infrastructure.Persistence.DataBases
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123456789");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<EntityBase>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TableConfiguration.StudentTableConfiguration).Assembly);
        }
    }
}
