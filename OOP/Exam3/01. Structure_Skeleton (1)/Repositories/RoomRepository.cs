using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly ICollection<IRoom> rooms;

        public RoomRepository()
        {
            rooms= new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            this.rooms.Add(model);
        }

        public IRoom Select(string criteria)
        {
            return this.rooms.First(r => r.GetType().Name == criteria);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return (IReadOnlyCollection<IRoom>)this.rooms;
        }

        
    }
}
