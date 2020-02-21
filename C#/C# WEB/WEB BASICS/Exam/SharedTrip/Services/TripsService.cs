using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(AddTripsInputModel input)
        {
            var trip = new Trip
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                DepartureTime = DateTime.ParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = input.Description,
                ImagePath = input.ImagePath,
                Seats = int.Parse(input.Seats),
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IEnumerable<TripViewModel> All()
        {
            return this.db.Trips
                .Select(x => new TripViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    Description = x.Description,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm")
                })
                .ToList();
        }

        public GetDetailsViewModel GetDetails(string id)
        {
            return this.db.Trips
                .Select(x => new GetDetailsViewModel
                {
                    Id = id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    Description = x.Description,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm")
                })
                .FirstOrDefault();
        }


        public bool AddUser(string tripId, string userId)
        {
            var userTripExist = this.db.UserTrips.Any(x => x.TripId == tripId && x.UserId == userId);


            var currentTrip = this.db.Trips.Find(tripId);
            if (currentTrip.Seats > 0)
            {
                currentTrip.Seats--;
            }

            if (userTripExist || currentTrip.Seats <= 0)
            {
                return false;
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };

            this.db.UserTrips.Add(userTrip);

            this.db.SaveChanges();
            return true;
        }

    }
}
