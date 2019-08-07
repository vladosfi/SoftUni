namespace PlayersAndMonsters.Core
{
    using System;
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO;
    
    public class Engine : IEngine
    {
        private IManagerController manager;
        private ConsoleReader consoleReader;
        private ConsoleWriter consoleWriter;

        public Engine()
        {
            this.manager = new ManagerController();
            consoleReader = new ConsoleReader();
            consoleWriter = new ConsoleWriter();
        }

        public void Run()
        {

            string input = consoleReader.ReadLine();

            while (input != "Exit")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];

                try
                {
                    if (command == "AddPlayer")
                    {
                        string playerType = inputArgs[1];
                        string userName = inputArgs[2];
                        consoleWriter.WriteLine(manager.AddPlayer(playerType, userName));
                    }
                    else if (command == "AddCard")
                    {
                        string cardType = inputArgs[1];
                        string cardName = inputArgs[2];
                        consoleWriter.WriteLine(manager.AddCard(cardType, cardName));
                    }
                    else if (command == "AddPlayerCard")
                    {
                        string userName = inputArgs[1];
                        string cardName = inputArgs[2];
                        consoleWriter.WriteLine(manager.AddPlayerCard(userName, cardName));
                    }
                    else if (command == "Fight")
                    {
                        string attackUser = inputArgs[1];
                        string enemyUser = inputArgs[2];

                        consoleWriter.WriteLine(manager.Fight(attackUser, enemyUser));
                    }
                    else if (command == "Report")
                    {
                        consoleWriter.WriteLine(manager.Report());
                    }
                }
                catch (ArgumentException ae)
                {
                    consoleWriter.WriteLine(ae.Message);
                }

                input = consoleReader.ReadLine();
            }
        }
    }
}
