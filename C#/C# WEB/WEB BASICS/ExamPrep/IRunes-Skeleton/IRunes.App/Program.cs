using SIS.MvcFramework;
using System.Threading.Tasks;

namespace IRunes.App
{
    public static class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
