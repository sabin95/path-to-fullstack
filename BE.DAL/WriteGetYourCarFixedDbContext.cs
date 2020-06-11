using Microsoft.EntityFrameworkCore;

namespace BE.DAL
{
    public class WriteGetYourCarFixedDbContext : DbContext
    {
        public WriteGetYourCarFixedDbContext(DbContextOptions<WriteGetYourCarFixedDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetClientAggregateResult>().HasNoKey();
        }
    }
}
