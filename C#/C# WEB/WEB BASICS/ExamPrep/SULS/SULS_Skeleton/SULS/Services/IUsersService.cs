using SULS.ViewModels;

namespace SULS.Services
{
    public interface IUsersService
    {
        void Register(string username, string password, string email);

        bool UserExist(string username);

        bool EmailExist(string email);

        string GetUserId(string username, string password);


    }
}
