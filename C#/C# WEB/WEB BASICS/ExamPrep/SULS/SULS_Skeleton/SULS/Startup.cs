using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using System.Collections.Generic;

namespace SULS
{
    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> serverRoutingTable)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IHomeService, HomeService>();
            serviceCollection.Add<ISubmisionsService, SubmisionsService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
        }
    }
}
