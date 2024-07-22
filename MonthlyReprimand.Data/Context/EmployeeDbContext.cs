using Microsoft.EntityFrameworkCore;
using MonthlyReprimand.Data.Entities;

namespace MonthlyReprimand.Data.Context
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Position> Positions { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Shifts)
                .WithOne(s => s.Employee)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<Position>()
                .HasData(
                    new Position { Id = 1, Name = "Менеджер" },
                    new Position { Id = 2, Name = "Инженер" },
                    new Position { Id = 3, Name = "Тестировщик свечей" }
                );
        }
    }
}
