using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.ViewModels;

namespace SULS.Controllers
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

            return this.View();
        }


        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }


        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters.");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters.");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Password should match.");
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Error("Email cannot be empty.");
            }

            if (this.usersService.UserExist(input.Username))
            {
                return this.Error("Username already exist.");
            }

            if (this.usersService.EmailExist(input.Email))
            {
                return this.Error("Email already exist.");
            }


            this.usersService.Register(input.Username, input.Password, input.Email);

            return this.Redirect("/Users/Login");
        }
    }
}
