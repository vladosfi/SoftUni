using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.ViewModels;

namespace SULS.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmisionsService submissionsService;

        public SubmissionsController(ISubmisionsService submissionsService)
        {
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            var problem = this.submissionsService.GetProblem(id);

            if (problem == null)
            {
                return this.Error("Problme does not exist.");
            }

            var model = new CreateSubmisionModel
            {
                Name = problem.Name,
                ProblemId = problem.Id,
            };


            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            if (code.Length < 30 || code.Length > 800)
            {
                return this.Error("Submision code lenght should be between 30 and 800 characters.");
            }

            this.submissionsService.CreateSubmision(problemId, code, this.User);

            return this.Redirect("/");
        }


        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            this.submissionsService.DeleteSubmision(id);

            return this.Redirect("/");
        }
    }
}
