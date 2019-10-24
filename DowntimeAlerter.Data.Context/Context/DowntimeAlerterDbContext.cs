using DowntimeAlerter.Domain.Entities;
using DowntimeAlerter.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DowntimeAlerter.Data.Context.Context
{
    public class DowntimeAlerterDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DowntimeAlerterDbContext(DbContextOptions<DowntimeAlerterDbContext> options) : base(options)
        {
        }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<HealthCheck> HealthChecks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Monitor>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<HealthCheck>().HasQueryFilter(x => !x.IsDeleted);

            base.OnModelCreating(builder);

            //Guid ADMIN_ID = Guid.NewGuid();
            //builder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Id = ADMIN_ID.ToString(),
            //    Name = "admin",
            //    NormalizedName = "admin"
            //});

            //var hasher = new PasswordHasher<AppUser>();
            //builder.Entity<AppUser>().HasData(new AppUser
            //{
            //    Id = ADMIN_ID,
            //    UserName = "admin",
            //    NormalizedUserName = "admin",
            //    Email = "admin@admin.com",
            //    NormalizedEmail = "admin@admin.com",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "admin"),
            //    SecurityStamp = string.Empty
            //});

            //builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = ADMIN_ID.ToString(),
            //    UserId = ADMIN_ID
            //});
        }

    }
}
