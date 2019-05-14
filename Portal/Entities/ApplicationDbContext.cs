using System.Linq;
using CryptoHelper;
using Microsoft.EntityFrameworkCore;

namespace Portal.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Head> Heads { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => { entity.HasIndex(e => e.Login).IsUnique(); });
            
            builder.Entity<Head>().HasKey(h => h.Email);

            builder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            builder.Entity<Role>()
                .HasData(new Role
                    {
                        Id = 2,
                        Name = "Basic",
                    },
                    new Role
                    {
                        Id = 1,
                        Name = "Admin",
                    });

            builder.Entity<User>()
                .HasData(new User
                    {
                        Id = 1,
                        Login = "admin",
                        Password = Crypto.HashPassword("admin"),
                        RoleId = 1,
                    },
                    new User
                    {
                        Id = 2,
                        Login = "user",
                        Password = Crypto.HashPassword("user"),
                        RoleId = 2,
                    });
            
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}