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
             new Room { Id = 1, name = "Lake View", layout= Room.Layout.OneBedroom },
             new Room { Id = 2, name = "Forest View", layout = Room.Layout.TwoBedroom },
             new Room { Id = 3, name = "Lake View Suite", layout = Room.Layout.Suite },
             new Room { Id = 4, name = "Rustic Cabin", layout = Room.Layout.Cabin },
             new Room { Id = 5, name = "The Lost Camp", layout = Room.Layout.Cabin },
             new Room { Id = 6, name = "Lover's Leap", layout = Room.Layout.Honeymoon },
             new Room { Id = 7, name = "The Lighthouse", layout = Room.Layout.Cabin }
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

            modelBuilder.Entity<RoomAmenity>()
                .HasData(
                new RoomAmenity {  AmenityId = 1, RoomId = 6},
                new RoomAmenity { AmenityId = 2, RoomId = 6 },
                new RoomAmenity { AmenityId = 3, RoomId = 6 },
                new RoomAmenity { AmenityId = 4, RoomId = 6 },
                new RoomAmenity { AmenityId = 5, RoomId = 6 },
                new RoomAmenity { AmenityId = 4, RoomId = 1 },
                new RoomAmenity { AmenityId = 4, RoomId = 2 },
                new RoomAmenity { AmenityId = 4, RoomId = 3 },
                new RoomAmenity { AmenityId = 4, RoomId = 4 },
                new RoomAmenity { AmenityId = 4, RoomId = 5 },
                new RoomAmenity { AmenityId = 4, RoomId = 7 }
                );
            modelBuilder.Entity<HotelRoom>()
            .HasKey(HotelRoom => new
            {
              HotelRoom.HotelId,
              HotelRoom.RoomId
            });
            modelBuilder.Entity<HotelRoom>()
                .HasData(
                new HotelRoom { HotelId = 1, RoomId = 1, Rate = 90.50, PetFriendly = true },
                new HotelRoom { HotelId = 2, RoomId = 2, Rate = 90.50, PetFriendly = true },
                new HotelRoom { HotelId = 3, RoomId = 3, Rate = 90.50, PetFriendly = true },
                new HotelRoom { HotelId = 4, RoomId = 6, Rate = 90.50, PetFriendly = true },
                new HotelRoom { HotelId = 5, RoomId = 4, Rate = 90.50, PetFriendly = true },
                new HotelRoom { HotelId = 5, RoomId = 5, Rate = 90.50, PetFriendly = true },
                new HotelRoom { HotelId = 5, RoomId = 7, Rate = 90.50, PetFriendly = true }
                );


        }
        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
    }
}
