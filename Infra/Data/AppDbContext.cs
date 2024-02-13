using concord_users.Infra.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace concord_users.Infra.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<UserModel> Users { get; set; } = null!;
    }
}
