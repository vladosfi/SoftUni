using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;
using System;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new AllTripsViewModel
            {
                Trips = this.tripsService.All()
            };

            return this.View(viewModel);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripsInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!int.TryParse(input.Seats,out int _))
            {
                return this.Redirect("/Trips/Add");
            }

            if (DateTime.TryParse(input.DepartureTime, out _))
            {
                return this.Redirect("/Trips/Add");
            }

            if (int.Parse(input.Seats) < 2 || int.Parse(input.Seats) > 6)
            {
                return this.Redirect("/Trips/Add");
            }

            if (input.Description.Length > 80)
            {
                return this.Redirect("/Trips/Add");
            }
            

            this.tripsService.Add(input);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.tripsService.GetDetails(tripId);
            return this.View(viewModel);
        }


        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var isUserAddedToTrip = this.tripsService.AddUser(tripId, this.User);

            if (isUserAddedToTrip)
            {
                return this.Redirect("/Trips/All");
            }

            return Redirect($"/Trips/Details?tripId={tripId}");
        }


    }
}
