using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class ApplicationDatabaseContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }


        public ApplicationDatabaseContext()
        {
        }


        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options)
               : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Manager");
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CustomerName)
                   .IsRequired()
                   .HasMaxLength(100); 

                entity.Property(e => e.CustomerMidName)
                   .IsRequired()
                   .HasMaxLength(100);

                entity.Property(e => e.CustomerSurname)
                   .IsRequired()
                   .HasMaxLength(100);

                entity.Property(e => e.CheckInDate);
                   


                entity.Property(e => e.CheckOutDate);
                   


                entity.Property(e => e.Currency);




                entity.Property(e => e.RoomNumber); 
            
                  



            });

         
    }
    }
}
