namespace MonthlyReprimand.Data.Context
{
    /// <summary>
    /// Unit of work - обёртка вокруг контекста для транзакций
    /// </summary>
    public class EmployeeUnitOfWork
    {
        private readonly EmployeeDbContext _db;

        public EmployeeUnitOfWork(EmployeeDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Открыть транзакцию 
        /// </summary>
        public async Task BeginTransaction()
        {
            await _db.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Закрыть транзакцию
        /// </summary>
        public async Task CommitTransaction()
        {
            await _db.Database.CommitTransactionAsync();
        }
    }
}
