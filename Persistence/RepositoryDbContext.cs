using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public sealed class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options) 
            : base(options) 
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Usuario Admin",
                    Email = "admin@demo.com",
                    Password = "123456" // En producción, ¡esto debería estar encriptado!
                }
            );
        }

    }
}
