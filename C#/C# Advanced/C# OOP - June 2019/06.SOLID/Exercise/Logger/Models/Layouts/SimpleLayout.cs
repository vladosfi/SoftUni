using LoggerTask.Models.Contracts;

namespace LoggerTask.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
