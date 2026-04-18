

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Roshetta.BLL.Authentication;
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
            services.AddScoped<IAuthService, AuthService>();
            

            return services;
        }

        public static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJwtProvider, JwtProvider>();

            services
            .AddIdentity<ApplicationUser, IdentityRole>()
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
