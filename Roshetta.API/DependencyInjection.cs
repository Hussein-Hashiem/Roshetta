using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Roshetta.BLL.Authentication;
using Roshetta.DAL.Repo.Abstraction;
using Roshetta.DAL.Repo.Implementation;
using System.Text;

namespace Roshetta.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers();
            services.AddOpenApi();
            services.AddValidationConfig()
                    .AddDependenciesConfig()
                    .AddAuthConfig(configuration);

            services.AddCors(options =>
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                )
            );

            // Connection String
            var connectionString = configuration.GetConnectionString("defaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));



            services.AddHttpContextAccessor();
            services.AddExceptionHandler<GlobaExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }

        public static IServiceCollection AddDependenciesConfig(this IServiceCollection services)
        {

            #region Repo
            services.AddScoped<IPatientRepo, PatientRepo>();
            services.AddScoped<IDoctorRepo, DoctorRepo>();
            services.AddScoped<IDoctorScheduleRepo, DoctorScheduleRepo>();
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            #endregion

            #region Service
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            #endregion

            return services;
        }

        public static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJwtProvider, JwtProvider>();

            services
            .AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KTVcuuOTiQkGaFkwtoUe7BKR8rrE7CKo")),
                    ValidIssuer = "RoshettaApp",
                    ValidAudience = "Roshetta users"
                };
            });


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });

            return services;
        }
        public static IServiceCollection AddValidationConfig(this IServiceCollection services)
        {
            // Diffrent Assembly
            services.AddBLLValidation();
            services.AddFluentValidationAutoValidation();
            return services;
        }
    }
}
