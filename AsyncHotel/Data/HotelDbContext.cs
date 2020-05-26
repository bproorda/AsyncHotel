using AsyncHotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Amenity>()
                .HasData(
                new Amenity { Id = 1, name = "Hot Tub"}
                );

            modelBuilder.Entity<Room>()
             .HasData(
             new Room { Id = 1, name = "Lake View", layout= Room.Layout.OneBedroom }
             );
        }
        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}
