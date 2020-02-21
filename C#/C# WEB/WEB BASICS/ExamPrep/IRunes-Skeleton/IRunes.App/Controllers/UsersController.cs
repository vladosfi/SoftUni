using IRunes.App.Services;
using IRunes.App.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.App.Controllers
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
                return this.Error("Username lenght should be between 4 and 10 characters.");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password lenght should be between 6 and 20 characters.");
            }

            if (input.Password != input.Password)
            {
                return this.Error("Passwords should match.");
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Error("Email cannot be empty.");
            }

            if (this.usersService.UserNameExist(input.Username))
            {
                return this.Error("User already exist.");
            }

            if (this.usersService.EmailExist(input.Email))
            {
                return this.Error("Email already exist.");
            }

            this.usersService.RegisterUser(input.Username, input.Password, input.Email);

            return this.Redirect("/");
        }
    }
}
