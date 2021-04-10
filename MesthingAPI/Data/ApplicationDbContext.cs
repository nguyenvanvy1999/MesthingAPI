using MesthingAPI.Models;
using MesthingAPI.Models.Auths;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MesthingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<DeviceModel> Devices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceModel>()
              .HasOne(p => p.IsActive)
              .WithMany(b => b.Devices)
              .HasForeignKey(p => p.IsActive);
        }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}


