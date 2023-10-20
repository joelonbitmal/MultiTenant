using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Models.Users;
using MultiTenant.Models.Branches;
using MultiTenant.Models.BranchUsers;

namespace MultiTenant.WebAPI.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet declarations here
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchUser> BranchUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchUser>()
                .HasKey(bu => new { bu.UserId, bu.BranchId });

            modelBuilder.Entity<BranchUser>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.BranchUsers)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<BranchUser>()
                .HasOne(sc => sc.Branch)
                .WithMany(c => c.BranchUsers)
                .HasForeignKey(sc => sc.BranchId);

            base.OnModelCreating(modelBuilder);

            // Seeding roles
            SeedRoles(modelBuilder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            string[] roleNames = { "Administrator", "Manager", "User" };

            foreach (var roleName in roleNames)
            {
                var role = new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                };

                builder.Entity<IdentityRole>().HasData(role);
            }
        }
    }
}
