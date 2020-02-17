using SharedTrip.ViewModels.Trips;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void Add(AddTripsInputModel input);

        IEnumerable<TripViewModel> All();

        GetDetailsViewModel GetDetails(string id);

        bool AddUser(string tripId, string userId);
    }
}
