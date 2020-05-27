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
                new Amenity { Id = 1, name = "Hot Tub"},
                new Amenity { Id = 2, name = "Kitchenette" },
                new Amenity { Id = 3, name = "Dining" },
                new Amenity { Id = 4, name = "Netflix" },
                new Amenity { Id = 5, name = "Safe" }
                );

            modelBuilder.Entity<Room>()
             .HasData(
             new Room { Id = 1, name = "Lake View", layout= Room.Layout.OneBedroom }
             );
            modelBuilder.Entity<Hotel>()
             .HasData(
             new Hotel { Id = 1, Name = "The Superior Hotel", StreetAddress = "1 Cherry Street", City = "Munising", State = "Michigan", Country = "USA", Phone = "387-555-1987" },
             new Hotel { Id = 2, Name = "Snowbound", City = "Copper Harbor", State = "Michigan"},
             new Hotel { Id = 3, Name = "Red Bay", City = "Ashland", State = "Wisconsin" },
             new Hotel { Id = 4, Name = "Duluth Inn", City = "Duluth", State = "Minnesota" },
             new Hotel { Id = 5, Name = "Last Stop", City = "Grand Marais", State = "Minnesota" }
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
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
    }
}
