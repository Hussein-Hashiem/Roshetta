using Microsoft.EntityFrameworkCore;
using Roshetta.DAL.Database;

namespace Roshetta.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers();
            services.AddOpenApi();

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
    }
}