﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoCompany.Model.Entities;

namespace ToDoCompany.Model.Context
{
    internal class CompanyDbContext : DbContext
    {
        public DbSet<EmployeeTask> Employee { get; set; }
        public DbSet<EmployeeTask> EmployeeTask { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=ToDoTask;Uid=root;Pwd=Code4321,;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>()
                .HasMany<EmployeeTask>()
                .WithOne(x => x.Employee)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}