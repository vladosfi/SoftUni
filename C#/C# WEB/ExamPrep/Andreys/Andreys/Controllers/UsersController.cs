using Andreys.Services;
using Andreys.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.Controllers
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
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId);

                return this.Redirect("/Home/Index");
            }
            
            return this.Redirect("/Users/Login");
        }


        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (input.Username.Length < 4 || input.Username.Length > 10)
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
