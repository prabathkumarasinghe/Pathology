﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pathology.Services.AuthAPI.Models;

namespace Pathology.Services.PatientAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);      
        }
    }
}
