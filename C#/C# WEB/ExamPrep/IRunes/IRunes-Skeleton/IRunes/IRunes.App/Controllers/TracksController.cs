using IRunes.App.Services;
using IRunes.App.ViewModels.Tracks;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.App.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksServivice;

        public TracksController(ITracksService tracksServivice)
        {
            this.tracksServivice = tracksServivice;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(albumId))
            {
                return Redirect("/Users/Login");
            }

            var viewModel = new CreateViewModel
            {
                AlbumId = albumId
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CraetaeInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("The name should be between 4 and 20 characters.");
            }

            if (!input.Link.StartsWith("http"))
            {
                return this.Error("Invalid link");
            }

            if (input.Price < 0)
            {
                return this.Error("Price should be a positive number.");
            }

            this.tracksServivice.Create(input.AlbumId, input.Name, input.Link, input.Price);

            return Redirect("/Albums/Details?id=" + input.AlbumId);
        }

        public HttpResponse Details(string albumId, string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            var viewModel = this.tracksServivice.GetDetails(albumId, trackId);

            return this.View(viewModel);
        }

    }
}
