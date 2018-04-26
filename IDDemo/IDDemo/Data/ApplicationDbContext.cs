using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IDDemo.Models;
using Microsoft.AspNetCore.Identity;
using IDDemo.Models.SuperUserViewModels;

namespace IDDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            base.OnModelCreating((builder));
            builder.Entity<ApplicationUser>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");
            builder.Entity<IdentityUserRole<string>>(entity=>entity.ToTable("UserRole"));
            builder.Entity<IdentityUserLogin<string>>(entity=>entity.ToTable("UserLogin"));
            builder.Entity<IdentityUserClaim<string>>(entity=>entity.ToTable("UserClaim").Property(p => p.Id).HasColumnName("UserClaimId"));
            builder.Entity<IdentityRole>().ToTable("Role").Property(p => p.Id).HasColumnName("RoleId");
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable("RoleClaim"));
            builder.Entity<IdentityUserToken<string>>(entity => entity.ToTable("UserToken"));
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<IDDemo.Models.SuperUserViewModels.RoleViewModel> RoleViewModel { get; set; }
    }
}
