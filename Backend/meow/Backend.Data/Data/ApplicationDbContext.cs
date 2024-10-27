using Backend.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
       .HasMany(u => u.Meetings)
       .WithMany(m => m.Users)
       .UsingEntity(j => j.ToTable("MeetingUser"));
        

            modelBuilder.Entity<User>()
                .HasMany(u => u.Availabilities)
                .WithMany(a => a.Users)
                .UsingEntity(j => j.ToTable("AvailabilityUser"));
        }
    }


}
