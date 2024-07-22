using MonthlyReprimand.Data.Context;
using MonthlyReprimand.Data.Repositories;

namespace MonthlyReprimand.DependencyInjection
{
    public static class RepositoryCollectionExtensions
    {
        public static IServiceCollection AddRepositoryes(this IServiceCollection services)
        {
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<ShiftRepository>();
            services.AddScoped<PositionRepository>();
            services.AddScoped<EmployeeUnitOfWork>();

            return services;
        }
    }
}
