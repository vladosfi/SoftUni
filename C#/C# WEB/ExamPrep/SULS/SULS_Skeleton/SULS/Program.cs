using SIS.MvcFramework;
using System.Threading.Tasks;

namespace SULS
{
    public static class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
