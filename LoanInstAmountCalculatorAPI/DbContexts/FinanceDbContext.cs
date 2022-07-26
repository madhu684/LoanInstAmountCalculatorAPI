using LoanInstAmountCalculatorAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanInstAmountCalculatorAPI.DbContexts
{
    public class FinanceDbContext: DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        {

        }

        public DbSet<CalculationType> CalculationTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalculationType>().HasData(new CalculationType[] {
                new CalculationType{Id=1,Name="Equal monthly installment"}
            });
        }
    }
}
