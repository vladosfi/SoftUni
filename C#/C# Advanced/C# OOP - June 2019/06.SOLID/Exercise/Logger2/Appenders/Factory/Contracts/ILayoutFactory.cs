using Logger2.Layouts.Contracts;

namespace Logger2.Factory.Contracts
{
    public interface ILayoutFactory
    {
        ILayout Create(string type);
    }
}
