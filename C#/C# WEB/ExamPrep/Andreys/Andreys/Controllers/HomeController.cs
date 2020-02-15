namespace Andreys.App.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IProductsService productsService;

        public HomeController(IUsersService usersService, IProductsService productsService)
        {
            this.usersService = usersService;
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewModel = new AllProductsViewModel
                {
                    Products = this.productsService.GetAll()
                };

                return this.View(viewModel, "Home");
            }


            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexFullPage()
        {
            return this.Index();
        }
    }
}
