namespace IRunes.App.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void Register(string username, string email, string password);

        bool UserNameExist(string username);

        bool EmailExist(string email);

        string GetUserName(string userId);
    }
}
