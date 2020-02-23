using IRunes.App.ViewModels.Users;
using IRunes.App.Services;
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

                return this.Redirect("/");
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
                return this.Error("Username shuld be between 4 and 10 symbols.");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password shuld be between 6 and 20 symbols.");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Password should match.");
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Error("Email cannot be empty.");
            }

            if (this.usersService.UserNameExist(input.Username))
            {
                return this.Error("Username already in use.");
            }

            if (this.usersService.EmailExist(input.Email))
            {
                return this.Error("Email already in use.");
            }

            this.usersService.Register(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
