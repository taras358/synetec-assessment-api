﻿using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain;
using System.Reflection;
using SynetecAssessmentApi.Domain.Entities;

namespace SynetecAssessmentApi.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
