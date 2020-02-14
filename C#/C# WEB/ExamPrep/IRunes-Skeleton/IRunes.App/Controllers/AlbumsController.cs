using IRunes.App.Services;
using IRunes.App.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.App.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsServices albumsServices;

        public AlbumsController(IAlbumsServices albumsServices)
        {
            this.albumsServices = albumsServices;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new AlbumsViewModel
            {
                Albums = this.albumsServices.GetAllAlbums(),
            };

            return this.View(viewModel);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateAlbumViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Name lenght should be between 4 and 20 characters.");
            }

            this.albumsServices.Create(input.Name, input.Cover);

            return this.Redirect("/Albums/All");
        }


        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.albumsServices.GetAlbum(id);

            return this.View(viewModel);
        }
    }
}
