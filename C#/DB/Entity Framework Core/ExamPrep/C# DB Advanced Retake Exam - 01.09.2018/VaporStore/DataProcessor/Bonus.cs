namespace VaporStore.DataProcessor
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;

    public static class Bonus
    {
        public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
        {
            var user = context
                .Users
                .FirstOrDefault(u => u.Username == username);

            var emails = context.Users.Select(e => e.Email).ToArray();


            if (user == null)
            {
                return $"User {username} not found";
            }
            else if (emails.Contains(newEmail))
            {
                return $"Email {newEmail} is already taken";
            }

            user.Email = newEmail;
            context.Users.Update(user);
            context.SaveChanges();
            return $"Changed {username}'s email successfully";
        }
    }
}
