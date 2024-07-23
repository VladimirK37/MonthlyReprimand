using MonthlyReprimand.Data.Context;
using MonthlyReprimand.Data.Repositories;
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

            services.AddScoped<EmployeeRepository>();
            services.AddScoped<ShiftRepository>();
            services.AddScoped<PositionRepository>();
            services.AddScoped<EmployeeUnitOfWork>();

            return services;
        }
    }
}
