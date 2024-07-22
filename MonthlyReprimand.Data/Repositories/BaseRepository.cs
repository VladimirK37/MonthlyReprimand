using MonthlyReprimand.Data.Context;

namespace MonthlyReprimand.Data.Repositories
{
    public class BaseRepository<TEntityClass> where TEntityClass : class
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        protected EmployeeDbContext DbContext { get; }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="dbContext"></param>
        protected BaseRepository(EmployeeDbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Получить все entity
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntityClass> GetAll()
        {
            return DbContext.Set<TEntityClass>();
        }
    }
}
