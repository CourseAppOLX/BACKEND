using Microsoft.EntityFrameworkCore;

namespace backendAPI.Data
{
    public class AppEFContext : DbContext
    {
        //public AppEFContext(DbContextOptions<AppEFContext> options)
        //    : base(options)
        //{

        //}


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        public AppEFContext(DbContextOptions<AppEFContext> options) : base(options)
        {
        }
    }
}
