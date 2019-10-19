
namespace StudentSystemCatalog
{
    using StudentSystemCatalog.Commands;
    using StudentSystemCatalog.Students;
    using System;

    public class Engine
    {
        private CommandParcer commandParcer;
        private StudentSystem studentSystem;

        private readonly Func<string> readInput;
        private readonly Action<string> writeOutput;

        public Engine(
            CommandParcer commandParcer, 
            StudentSystem studentSystem,
            Func<string> readInput,
            Action<string> writeOutput)
        {
            this.commandParcer = commandParcer;
            this.studentSystem = studentSystem;
            this.readInput = readInput;
            this.writeOutput = writeOutput;
        }

        public void Run()
        { 
            while (true)
            {
                var command = commandParcer.Parce(readInput());

                if (command.Name == "Create")
                {
                    studentSystem.Add(command.Arguments);
                }
                else if (command.Name == "Show")
                {
                    var name = command.Arguments[0];
                    var student = studentSystem.Get(name);
                    writeOutput(student.ToString());
                }
                else if (command.Name == "Exit")
                {
                    break;
                }
            }
        }
    }
}
