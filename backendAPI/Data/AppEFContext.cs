using backendAPI.Data.Entities;
using backendAPI.Data.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendAPI.Data
{
    public class AppEFContext : IdentityDbContext<UserEntity, RoleEntity, int,
        IdentityUserClaim<int>, UserRoleEntity, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
       
        public DbSet<BasketEntity> Baskets { get; set; }
        //public DbSet<UserEntity> Users { get; set; } // Додайте цю властивість

        public AppEFContext(DbContextOptions<AppEFContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // gpt code
            base.OnModelCreating(builder);

            builder.Entity<IdentityUserLogin<int>>().HasKey(e => new { e.LoginProvider, e.ProviderKey });
            ///

            builder.Entity<RoleEntity>()
        .Property(r => r.Id)
       .ValueGeneratedNever(); // Відключити автогенерацію для Id


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
