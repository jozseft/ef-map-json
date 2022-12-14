using MapJSON.Data.Context;
using MapJSON.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapJSON.Data.Repositories
{
    public interface ITripRepository 
    {
        void AddTrip(Trip trip);

        List<Trip> GetTrips(Guid userId);
    }

    public class TripRepository : ITripRepository
    {
        private readonly MapJSONContext _context;

        public TripRepository(MapJSONContext context)
        {
            _context = context;
        }

        public void AddTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
        }

        public List<Trip> GetTrips(Guid userId) 
        {
            return _context.Trips.Where(t => t.UserId == userId).ToList();
        }
    }
}
