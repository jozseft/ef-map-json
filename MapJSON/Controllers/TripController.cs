using MapJSON.Data.Entities;
using MapJSON.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapJSON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;

        public TripController(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        [HttpPost]
        public void AddTrip() 
        {
            Guid userId = Guid.Parse("d91cc85e-ba5a-41bc-baed-4b18abb3275b");
            Trip trip = new Trip
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = "Sign contract",
                FinalDestination = "Munich",
                Transits = new List<TransitDetail>()
                {
                    new TransitDetail { StartingPoint = "Oradea", Destination = "Cluj-Napoca", TransportationMode = "train", TicketPrice = 10.10m },
                    new TransitDetail { StartingPoint = "Cluj-Napoca", Destination = "Munich", TransportationMode = "flight", TicketPrice = 40.10m }
                }
            };

            _tripRepository.AddTrip(trip);

            Trip trip2 = new Trip
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = "Extend contract",
                FinalDestination = "London"
            };

            _tripRepository.AddTrip(trip2);
        }

        [HttpGet]
        public List<Trip> GetUsers(Guid userId)
        {
            return _tripRepository.GetTrips(userId);
        }
    }
}
