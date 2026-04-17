public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDependencies(builder.Configuration);


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));

        app.UseHttpsRedirection();
        app.UseCors("AllowAll");

        app.UseAuthorization();


        app.MapControllers();

        app.UseExceptionHandler();

        app.MapStaticAssets();

        app.Run();
    }
}