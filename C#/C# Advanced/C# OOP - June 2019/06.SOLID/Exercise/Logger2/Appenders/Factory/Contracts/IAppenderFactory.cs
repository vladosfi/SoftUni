using Logger2.Appenders;
using Logger2.Layouts.Contracts;

namespace Logger2.Factory.Contracts
{
    public interface IAppenderFactory
    {
        IAppender Create(string type, ILayout layout);
    }
}
