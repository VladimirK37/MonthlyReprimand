using Microsoft.EntityFrameworkCore;
using MonthlyReprimand.Data.Context;
using MonthlyReprimand.Data.Entities;

namespace MonthlyReprimand.Data.Repositories
{
    /// <summary>
    /// Репозиторий сотрудника
    /// </summary>
    public class EmployeeRepository : BaseRepository<Employee>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="context"></param>
        public EmployeeRepository(EmployeeDbContext context) : base(context) { }

        /// <summary>
        /// Получение всех сотрудников
        /// </summary>
        /// <returns></returns>
        public IQueryable<Employee> GetAllEmployees()
        {
            return DbContext.Employees
                .Include(s => s.Position)
                .Include(e => e.Shifts);
        }

        /// <summary>
        /// Получение всех сотрудников по должности 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Employee> GetAllEmployeesByPositionId(int positionId)
        {
            return DbContext.Employees
                .Include(s => s.Position)
                .Include(e => e.Shifts)
                .Where(p => p.Position.Id == positionId);
        }

        /// <summary>
        /// Получение сотрудника по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await DbContext.Employees
                .Include(s => s.Shifts)
                .Include(p => p.Position)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task RemoveEmployeeAsync(Employee employee)
        {
            await DbContext.Employees
                .Where(x => x.Id == employee.Id)
                .ExecuteDeleteAsync();
        }

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task AddEmployeeAsync(Employee employee)
        {
            await DbContext.Employees.AddAsync(employee);
        }
    }
}
