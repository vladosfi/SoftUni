using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.ViewModels;

namespace SULS.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            var viewModel = this.problemsService.GetProblemDetails(id);

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
        public HttpResponse Create(ProblemCreateInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            if (input.Name.Length < 5 || input.Name.Length > 20)
            {
                return this.Error("Name should be between 5 and 20 characters.");
            }

            if (input.Points < 50 || input.Points > 300)
            {
                return this.Error("Points should be between 50 and 300");
            }

            this.problemsService.CreateProblem(input.Name, input.Points);

            return this.Redirect("/");
        }
    }
}
