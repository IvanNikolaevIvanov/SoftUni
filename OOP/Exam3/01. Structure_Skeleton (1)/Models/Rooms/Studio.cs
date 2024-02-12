using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public class Studio : Room, IRoom
    {
        private const int BED_CAPACITY = 4;

        public Studio() : base(BED_CAPACITY)
        {
        }
    }
}
