using BE.Queries.Clients;
using BE.Queries.Clients.Cars;
using BE.Queries.Clients.Revisions;
using Microsoft.EntityFrameworkCore;

namespace BE.Queries
{
    public class ReadGetYourCarFixedDbContext : DbContext
    {
        public ReadGetYourCarFixedDbContext(DbContextOptions<ReadGetYourCarFixedDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetAllRevisionsResult>().HasNoKey();
            modelBuilder.Entity<GetRevisionsForClientResult>().HasNoKey();
            modelBuilder.Entity<GetRevisionResult>().HasNoKey();
            modelBuilder.Entity<GetAllCarsForClientResult>().HasNoKey();
            modelBuilder.Entity<GetCarResult>().HasNoKey();
            modelBuilder.Entity<GetClientResult>().HasNoKey();
        }
    }
}
