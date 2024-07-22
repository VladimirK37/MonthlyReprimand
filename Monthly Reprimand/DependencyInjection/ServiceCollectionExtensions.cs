using MonthlyReprimand.Services;

namespace MonthlyReprimand.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<EmployeeService>();
            services.AddScoped<ShiftService>();
            services.AddScoped<PositionService>();

            return services;
        }
    }
}
