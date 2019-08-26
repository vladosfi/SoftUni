using Logger2.Loggers.Contracts;
using System.Linq;

namespace Logger2.Loggers
{
    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string message)
        {
            this.Size += message.Where(char.IsLetter).Sum(c=>c);
        }
    }
}
