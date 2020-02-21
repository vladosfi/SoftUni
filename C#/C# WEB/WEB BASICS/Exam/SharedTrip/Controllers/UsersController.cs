using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }


        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }


        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId);

                return this.Redirect("/Trips/All");
            }

            return this.View();
        }


        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password != input.Password)
            {
                return this.Redirect("/Users/Register");
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.UserNameExist(input.Username))
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.EmailExist(input.Email))
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.RegisterUser(input.Username, input.Password, input.Email);

            return this.Redirect("/Users/Login");
        }
    }
}
