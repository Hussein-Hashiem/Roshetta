namespace Roshetta.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBLLValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            return services;
        }
    }
}
