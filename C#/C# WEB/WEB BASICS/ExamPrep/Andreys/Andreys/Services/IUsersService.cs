namespace Andreys.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void RegisterUser(string username, string password, string email);

        bool UserNameExist(string username);

        bool EmailExist(string email);

        string GetUserName(string userId);
    }
}
