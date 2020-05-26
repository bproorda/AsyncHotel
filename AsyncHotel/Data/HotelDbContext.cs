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
            modelBuilder.Entity<Hotel>()
             .HasData(
             new Hotel { Id = 1, Name = "The Superior Hotel", StreetAddress = "1 Cherry Street", City = "Munising", State = "Michigan", Country = "USA", Phone = "387-555-1987" }
             );

            modelBuilder.Entity<RoomAmenity>()
          .HasKey(RoomAmenity => new
          {
              RoomAmenity.AmenityId,
              RoomAmenity.RoomId
          });
            modelBuilder.Entity<HotelRoom>()
            .HasKey(HotelRoom => new
            {
              HotelRoom.HotelId,
              HotelRoom.RoomId
            });


        }
        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
