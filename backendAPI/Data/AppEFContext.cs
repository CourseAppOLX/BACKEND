using backendAPI.Data.Entities;
using backendAPI.Data.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace backendAPI.Data
{
    public class AppEFContext : DbContext
    {
       
        public DbSet<BasketEntity> Baskets { get; set; }
        public AppEFContext(DbContextOptions<AppEFContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserRoleEntity>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(r => r.RoleId)
                    .IsRequired();

                ur.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(u => u.UserId)
                    .IsRequired();
            });
            builder.Entity<BasketEntity>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.ProductId });
            });

        }
    }
}
