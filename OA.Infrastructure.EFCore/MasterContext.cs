using Microsoft.EntityFrameworkCore;
using OA.Domain.UserAgg;
using OA.Infrastructure.EFCore.Mappings;

namespace OA.Infrastructure.EFCore
{
    public class MasterContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
