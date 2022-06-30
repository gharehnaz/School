using ESchool.Application.Application.Contracts.Role;
using ESchool.Domain.AccountAgg;
using ESchool.Domain.ClassRoomAgg;
using ESchool.Domain.CourseAgg;
using ESchool.Domain.RoleAgg;
using ESchool.Domain.SchoolAgg;
using ESchool.Infrastructure.Mapping;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace ESchool.Infrastructure.Context
{
    public class ESchoolContext:DbContext
    {
        public ESchoolContext(DbContextOptions<ESchoolContext> options) : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(RolesMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new SeedRole { Id = 1, Name = "مدیر سیستم",CreationDate= DateTime.Now });
            modelBuilder.Entity<Role>().HasData(new SeedRole { Id = 2, Name ="مدیر مدرسه", CreationDate = DateTime.Now });
            modelBuilder.Entity<Role>().HasData(new SeedRole { Id = 3, Name = "معلم", CreationDate = DateTime.Now });
        }
    }
}
