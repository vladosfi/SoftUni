using LoggerTask.Models.Enumerations;

namespace LoggerTask.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        
        Level Level { get; }

        void Append(IError error);
    }
}
