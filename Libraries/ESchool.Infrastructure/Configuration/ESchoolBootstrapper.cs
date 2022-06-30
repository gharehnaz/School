using ESchool.Application.Application;
using ESchool.Application.Application.Contracts.Account;
using ESchool.Application.Application.Contracts.ClassRoom;
using ESchool.Application.Application.Contracts.Course;
using ESchool.Application.Application.Contracts.Role;
using ESchool.Application.Application.Contracts.School;
using ESchool.Application.Application.Contracts.Student;
using ESchool.Application.IRepository;
using ESchool.Infrastructure.Context;
using ESchool.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ESchool.Infrastructure.Configuration
{
    public class ESchoolBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ISchoolApplication, SchoolApplication>();
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<IClassRoomApplication, ClassRoomApplication>();
            services.AddTransient<IClassRoomRepository, ClassRoomRepository>();
            services.AddTransient<IAccountApplication, AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IStudentApplication, StudentApplication>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ICourseApplication, CourseApplication>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddDbContext<ESchoolContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
