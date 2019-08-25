using Logger2.Layouts.Contracts;

namespace Logger2.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}"; 
    }
}
