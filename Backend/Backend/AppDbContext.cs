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

            //relations
            SetPrivilegesProfilesRelation(modelBuilder);
        }

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

        private void SetPrivilegesProfilesRelation(ModelBuilder modelBuilder)
        {
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
    }
}
