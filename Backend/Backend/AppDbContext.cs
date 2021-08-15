using Backend.Models.ShopPanelModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class AppDbContext : DbContext
    {
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfilesPrivileges> ProfilesPrivileges { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuration
            ConfigurePrivileges(modelBuilder);
            ConfigureProfiles(modelBuilder);
            ConfigureEmployees(modelBuilder);

            //relations
            SetPrivilegesProfilesRelation(modelBuilder);
            SetEmplooyesProfilesRelation(modelBuilder);
        }

        // konfiguracje:
        private void ConfigurePrivileges(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Privilege>()
                .Property(p => p.Name).HasMaxLength(30);
        }

        private void ConfigureProfiles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .Property(p => p.Name).HasMaxLength(30);
        }

        private void ConfigureEmployees(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Surname).HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Email).HasMaxLength(30);
            // todo tutaj prawdopodobnie trzeba będzie zrobić właściwość do hasła
        }

        // relacje:
        private void SetPrivilegesProfilesRelation(ModelBuilder modelBuilder)
        {
            // relacja many to many:
            modelBuilder.Entity<ProfilesPrivileges>()
                 .HasKey(pp => new { pp.PrivilegeId, pp.ProfileId });
            modelBuilder.Entity<ProfilesPrivileges>()
                .HasOne(pp => pp.Profile)
                .WithMany(p => p.ProfilesPrivileges)
                .HasForeignKey(pp => pp.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProfilesPrivileges>()
                .HasOne(pp => pp.Privilege)
                .WithMany(p => p.ProfilesPrivileges)
                .HasForeignKey(pp => pp.PrivilegeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetEmplooyesProfilesRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeesProfiles>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProfileId });
            modelBuilder.Entity<EmployeesProfiles>()
                .HasOne(ep => ep.Profile)
                .WithMany(ep => ep.EmployeesProfiles)
                .HasForeignKey(ep => ep.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
