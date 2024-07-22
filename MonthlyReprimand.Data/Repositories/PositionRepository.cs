using Microsoft.EntityFrameworkCore;
using MonthlyReprimand.Data.Context;
using MonthlyReprimand.Data.Entities;

namespace MonthlyReprimand.Data.Repositories
{
    /// <summary>
    /// Репозиторий должности
    /// </summary>
    public class PositionRepository : BaseRepository<Position>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="context"></param>
        public PositionRepository(EmployeeDbContext context) : base(context) { }

        /// <summary>
        /// Получение всех должностей
        /// </summary>
        /// <returns></returns>
        public IQueryable<Position> GetAllPositions()
        {
            return DbContext.Positions;
        }

        /// <summary>
        /// Получение должности по имени
        /// </summary>
        /// <param name="positionName"></param>
        /// <returns></returns>
        public async Task<Position?> GetPositionByNameAsync(string positionName)
        {
            return await DbContext.Positions
                                  .FirstOrDefaultAsync(x => x.Name == positionName);
        }
    }
}
