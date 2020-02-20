using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.ViewModels;

namespace SULS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return IndexLoggedIn();
            }

            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse IndexLoggedIn()
        {
            if (this.IsUserLoggedIn())
            {
                var model = new AllProblemsModel
                {
                    Problems = this.homeService.GetAllProblems()
                };

                return this.View(model);
            }

            return this.Index();
        }
    }
}
