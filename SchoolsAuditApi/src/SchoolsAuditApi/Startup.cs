using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SchoolsAudit.Repository;
using SchoolsAuditDomainModel.Membership;
using SchoolsAuditDomainModel.Persistence;
using SchoolsAuditDomainModel.Membership.Stores;

namespace SchoolsAudit
{
    class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISchoolViewModelRepository, SchoolViewModelRepository>();

            services.AddScoped<IUserViewModelRepository, UserViewModelRepository>();

            services.AddScoped<IDocumentViewModelRepository, DocumentViewModelRepository>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options => options.AddPolicy("CorsDefault", policy => policy.WithOrigins(                "http://localhost:5002")
                .AllowAnyHeader()
                .AllowAnyMethod()));

            services.AddIdentity<User, Role>()
                .AddUserStore<MembershipUserStore>()
                .AddRoleStore<MembershipRoleStore>()
                .AddDefaultTokenProviders();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsDefault");

            app.UseIdentity();

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:5000",
                RequireHttpsMetadata = false,
                ApiName = "schoolsAuditApi"
            });

            app.UseMvc();
        }

    }
}