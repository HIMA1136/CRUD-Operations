using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Category_Type_Project.Models
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CategoryType>().HasData(
                new CategoryType
                {
                    Id = 1,
                    Name = "store",
                }
            );
            
            builder.Entity<CategoryType>().HasData(
                new CategoryType
                {
                    Id = 2,
                    Name = "service",
                }
            );
  
            builder.Entity<CategoryType>().HasData(
                new CategoryType
                {
                    Id = 3,
                    Name = "none",
                }
            );
        }
    }
}
