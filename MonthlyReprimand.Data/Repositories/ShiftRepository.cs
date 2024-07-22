using MonthlyReprimand.Data.Context;
using MonthlyReprimand.Data.Entities;

namespace MonthlyReprimand.Data.Repositories
{
    /// <summary>
    /// Репозиторий смены 
    /// </summary>
    public class ShiftRepository : BaseRepository<Shift>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="context"></param>
        public ShiftRepository(EmployeeDbContext context) : base(context) { }

        /// <summary>
        /// Получение всех смен
        /// </summary>
        public IQueryable<Shift> GetAllShifts()
        {
            return DbContext.Shifts;
        }

        /// <summary>
        /// Добавить смену
        /// </summary>
        /// <param name="shift"></param>
        public async Task AddShiftAsync(Shift shift)
        {
            await DbContext.Shifts.AddAsync(shift);
        }
    }
}
