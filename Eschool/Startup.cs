using ESchool.Infrastructure.Configuration;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace ESchool.Web
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            var connectionString = Configuration.GetConnectionString("ESchoolDb");
            ESchoolBootstrapper.Configure(services, connectionString);

            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddTransient<IAuthHelper, AuthHelper>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
              {
                  o.LoginPath = new PathString("/Index");
                  o.LogoutPath = new PathString("/Index");
                  o.AccessDeniedPath = new PathString("/Home/AccessDenied");
                  o.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
              });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminArea",
                    builder => builder.RequireRole(new List<string> { SystemRoles.Administrator, SystemRoles.Manager, SystemRoles.Teacher }));

                options.AddPolicy("ClassRoom",
                    builder => builder.RequireRole(new List<string> { SystemRoles.Administrator, SystemRoles.Manager, SystemRoles.Teacher }));

                options.AddPolicy("Role",
                    builder => builder.RequireRole(new List<string> { SystemRoles.Administrator }));

                options.AddPolicy("Account",
                    builder => builder.RequireRole(new List<string> { SystemRoles.Administrator, SystemRoles.Manager }));
                options.AddPolicy("School",
                    builder => builder.RequireRole(new List<string> { SystemRoles.Administrator}));
                options.AddPolicy("Student",
                    builder => builder.RequireRole(new List<string> { SystemRoles.Manager , SystemRoles.Administrator }));
                options.AddPolicy("Course",
                    builder => builder.RequireRole(new List<string> { SystemRoles.Administrator,SystemRoles.Manager, SystemRoles.Teacher }));

            });

            //services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
            //    builder
            //        .WithOrigins("https://localhost:5002")
            //        .AllowAnyHeader()
            //        .AllowAnyMethod()));

            //services.AddRazorPages().AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
            //    .AddRazorPagesOptions(options =>
            //    {
            //        options.Conventions.AuthorizeAreaFolder("Admin", "/", "AdminArea");
            //        options.Conventions.AuthorizeAreaFolder("Admin", "/ClassRoom/", "ClassRoom");
            //        options.Conventions.AuthorizeAreaFolder("Admin", "/Controllers/Role/", "Role");
            //        options.Conventions.AuthorizeAreaFolder("Admin", "/Controllers/Account/", "Account");
            //        options.Conventions.AuthorizeAreaFolder("Admin", "/Controllers/School/", "School");
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );

                //endpoints.MapControllers();
            });
       
        }
    }
}
