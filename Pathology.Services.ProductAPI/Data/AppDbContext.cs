using Microsoft.EntityFrameworkCore;
using Pathology.Services.TestAPI.Models;

namespace Pathology.Services.TestAPI.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Test> tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Test>().HasData(new Test
            {
                TestId = 1,
                Name = "FBC",
                Price = 15,
                Description = " NA",
                ImageUrl = "https://placehold.co/603x403",
                CategoryName = "NA"
            });
            modelBuilder.Entity<Test>().HasData(new Test
            {
                TestId = 2,
                Name = "Lipid",
                Price = 13.99,
                Description = "NA",
                ImageUrl = "https://placehold.co/602x402",
                CategoryName = "NA"
            });
            modelBuilder.Entity<Test>().HasData(new Test
            {
                TestId = 3,
                Name = "LFT",
                Price = 10.99,
                Description = "NA",
                ImageUrl = "https://placehold.co/601x401",
                CategoryName = "NA"
            });
            modelBuilder.Entity<Test>().HasData(new Test
            {
                TestId = 4,
                Name = "Sugar",
                Price = 15,
                Description = "NA",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "NA"
            });

        }
    }
}
