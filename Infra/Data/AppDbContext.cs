using concord_users.Infra.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace concord_users.Infra.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<UserModel> Users { get; set; } = null!;

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel &&
                (x.State == EntityState.Added || 
                x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                DateTime now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((BaseModel)entity.Entity).CreatedAt = now;
                }
                ((BaseModel)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
