using IRunes.App.Services;
using IRunes.App.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.App.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CreateTrackViewModel
            {
                AlbumId = albumId
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateTrackViewInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Name lenght should be between 4 and 20 characters.");
            }

            if (input.Price < 0)
            {
                return this.Error("Price should be a positive number.");
            }

            this.tracksService.Create(input.Name, input.Link, input.Price, input.AlbumId);

            return this.Redirect("/Albums/Details?id=" + input.AlbumId);
        }



        public HttpResponse Details(string albumId, string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var inputModel = this.tracksService.Details(albumId, trackId);

            return this.View(inputModel);
        }
    }
}
