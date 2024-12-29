using Microsoft.EntityFrameworkCore;
using Pathology.Services.PatientsAPI.Models;





namespace Pathology.Services.PatientsAPI.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                PatientNumber = 1,
                RefNumber = 1212,
                LabNumber = 02390,
                PatientName = "Nimal",
                Age = 10,
                Sex = "male",
                TestType = "FBC",
                CreatedDate = DateTime.Now,


            });
            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                PatientNumber = 2,
                RefNumber = 1099,
                LabNumber = 0412,
                PatientName = "Nimala",
                Age = 12,
                Sex = "Female",
                TestType = "Suger",
                CreatedDate = DateTime.Now,

            });

        }
    }
}
