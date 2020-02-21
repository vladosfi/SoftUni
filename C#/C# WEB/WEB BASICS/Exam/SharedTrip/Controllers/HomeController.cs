namespace SharedTrip.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    { 
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.User != null)
            {
                this.SignIn(this.User);

                return this.Redirect("/Trips/All");
            }
            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexForLogedIn()
        {
            return this.Index();
        }

        
    }
}