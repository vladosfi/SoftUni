using IRunes.App.ViewModels.Albums;
using IRunes.App.Services;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.App.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            var viewModel = new AllAlbumsViewModel
            {
                Albums = albumsService.GetAll()
            };

            return this.View(viewModel);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Name shoul be with lenght between 4 and 20");
            }

            if (string.IsNullOrWhiteSpace(input.Cover))
            {
                return this.Error("Cover is required");
            }

            this.albumsService.Create(input.Name, input.Cover);


            return Redirect("/Albums/All");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }


            var viewModel = this.albumsService.GetDetails(id);
            return this.View(viewModel);
        }
    }
}
