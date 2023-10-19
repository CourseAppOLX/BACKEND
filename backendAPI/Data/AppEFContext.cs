using backendAPI.Data.Entities;
using backendAPI.Data.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD
using backendAPI.Data.Entities.category;
=======
>>>>>>> f0834f38439bff0e5bd32e05f7d5e1b133f7b843

namespace backendAPI.Data
{
    public class AppEFContext : IdentityDbContext<UserEntity, RoleEntity, int,
        IdentityUserClaim<int>, UserRoleEntity, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
       
       public DbSet<BasketEntity> Baskets { get; set; }
<<<<<<< HEAD
        public DbSet<CategoryEntity> Categories { get; set; }


=======
       
>>>>>>> f0834f38439bff0e5bd32e05f7d5e1b133f7b843
        public AppEFContext(DbContextOptions<AppEFContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
<<<<<<< HEAD
         
=======
            //builder.Entity<RoleEntity>()
            //    .Property(r => r.Id)
            //     .ValueGeneratedNever(); // Відключити автогенерацію для Id
            // gpt code
>>>>>>> f0834f38439bff0e5bd32e05f7d5e1b133f7b843
            base.OnModelCreating(builder);

            builder.Entity<IdentityUserLogin<int>>().HasKey(e => new { e.LoginProvider, e.ProviderKey });
            ///


<<<<<<< HEAD
         
=======

>>>>>>> f0834f38439bff0e5bd32e05f7d5e1b133f7b843

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
<<<<<<< HEAD
            builder.Entity<CategoryEntity>().HasKey(c => c.Name);
=======
>>>>>>> f0834f38439bff0e5bd32e05f7d5e1b133f7b843

        }
    }
}
