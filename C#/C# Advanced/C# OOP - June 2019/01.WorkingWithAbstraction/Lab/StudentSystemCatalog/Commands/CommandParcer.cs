namespace StudentSystemCatalog.Commands
{
    using System.Linq;

    public class CommandParcer
    {
        public Command Parce(string command)
        {
            var parts = command.Split();

            return new Command
            {
                Name = parts[0],
                Arguments = parts.Skip(1).ToArray()
            };
        }
    }
}
