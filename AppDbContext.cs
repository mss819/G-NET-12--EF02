using G_NET_12_EF02.Configuration;
using G_NET_12_EF02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_12_EF02
{
    internal class AppDbContext:DbContext

    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=.;Database=EventHub;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organizer>(en => 
            {
                en.ToTable("Organizers").HasKey(e=>e.id); 
                en.Property(e=>e.id).ValueGeneratedOnAdd();
                en.Property(e=>e.Name).HasColumnType("nvarchar(50)").IsRequired();
                en.Property(e=>e.CompanyName).HasColumnType("nvarchar(50)").IsRequired();
                en.Property(e=>e.IsVerified).HasColumnType("bit").IsRequired();


            });
            modelBuilder.Entity<OrganizerProfile>(en => 
            {
                en.ToTable("OrganizerProfiles").HasKey(e=>e.id);
                en.Property(e => e.id).ValueGeneratedOnAdd();
                en.Property(e=>e.Bio).HasColumnType("nvarchar(250)").IsRequired(false);
                en.Property(e=>e.Website).HasColumnType("nvarchar(100)").IsRequired();
                en.Property(e=>e.LogoURL).HasColumnType("nvarchar(250)").IsRequired();


            });
            modelBuilder.Entity<Registration>(en => 
            {
                en.ToTable("Registrations").HasKey(e=>e.id);
                en.Property(e => e.id).ValueGeneratedOnAdd();
                en.Property(e=>e.Note).HasColumnType("nvarchar(250)").IsRequired(false);
                en.Property(e=>e.AttendeeId).HasColumnType("nvarchar(100)").IsRequired();

            });
            modelBuilder.ApplyConfiguration<Event>(new EventConfig());
            modelBuilder.ApplyConfiguration<Badge>(new BadgeConfig());
            modelBuilder.ApplyConfiguration<Address>(new AddressConfig());
            
        }
    }
}
