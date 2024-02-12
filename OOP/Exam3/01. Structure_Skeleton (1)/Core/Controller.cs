using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private IRepository<IHotel> hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = new Hotel(hotelName, category);

            if (this.hotels.Select(hotelName) != null)
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            this.hotels.AddNew(hotel);

            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);

        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (this.hotels.Select(hotelName) == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            var hotel = this.hotels.Select(hotelName);

            if (hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return String.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
            

            //Type roomType = Type.GetType(roomTypeName);
            //object room = Activator.CreateInstance(roomType);

            //var hotel = this.hotels.Select(hotelName);

            //hotel.Rooms.AddNew((IRoom)room);
            IRoom room = null;
            if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
            }
            else if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            

            hotel.Rooms.AddNew(room);

            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);

        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (this.hotels.Select(hotelName) == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            var hotel = this.hotels.Select(hotelName);

            if (roomTypeName != "Apartment" && roomTypeName != "Studio"
                && roomTypeName != "DoubleBed")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);

            }

            if (!hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return String.Format(OutputMessages.RoomTypeNotCreated);
            }

            var room = hotel.Rooms.Select(roomTypeName);

            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);

            }

            room.SetPrice(price);

            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> orderedHotels = this.hotels.All().Where(h => h.Category == category).OrderBy(h => h.FullName).ToList();

            int bookingNumber = 0;

            IHotel curHotel = null;

            IRoom room = null;

            if (orderedHotels.Count == 0)
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }
         
            foreach (var hotel in orderedHotels)
            {
                List<IRoom> selectedRooms = hotel.Rooms.All().Where(r => r.PricePerNight > 0).ToList();

                List<IRoom> orderedRooms = selectedRooms.OrderBy(r => r.BedCapacity).ToList();

                room = orderedRooms.FirstOrDefault(r => r.BedCapacity >= (adults + children));

                if (room != null)
                {
                    curHotel = hotel;
                    break;
                }
           
            }
            if (room == null)
            {
                return String.Format(OutputMessages.RoomNotAppropriate);
            }

            bookingNumber = curHotel.Bookings.All().Count() + 1;

            IBooking booking = new Booking(room, duration, adults, children, bookingNumber);

            curHotel.Bookings.AddNew(booking);
            return String.Format(OutputMessages.BookingSuccessful, bookingNumber, curHotel.FullName);

        }

        public string HotelReport(string hotelName)
        {
            if (this.hotels.Select(hotelName) == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            var hotel = this.hotels.Select(hotelName);

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Hotel name: {hotel.FullName}")
                .AppendLine($"--{hotel.Category} star hotel")
                .AppendLine($"--Turnover: {hotel.Turnover:F2} $")
                .AppendLine($"--Bookings:")
                .AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb
                        .AppendLine(booking.BookingSummary())
                        .AppendLine();
                }
            }

            return sb.ToString().TrimEnd();
        }

        

        
    }
}
