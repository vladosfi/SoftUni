using PlayersAndMonsters.Core.Contracts;
using System;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        IManagerController manager;

        public Engine()
        {
            this.manager = new ManagerController();
        }

        public void Run()
        {

            string input = Console.ReadLine();

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
                        Console.WriteLine(manager.AddPlayer(playerType, userName));
                    }
                    else if (command == "AddCard")
                    {
                        string cardType = inputArgs[1];
                        string cardName = inputArgs[2];
                        Console.WriteLine(manager.AddCard(cardType, cardName));
                    }
                    else if (command == "AddPlayerCard")
                    {
                        string userName = inputArgs[1];
                        string cardName = inputArgs[2];
                        Console.WriteLine(manager.AddPlayerCard(userName, cardName));
                    }
                    else if (command == "Fight")
                    {
                        string attackUser = inputArgs[1];
                        string enemyUser = inputArgs[2];

                        Console.WriteLine(manager.Fight(attackUser, enemyUser));
                    }
                    else if (command == "Report")
                    {
                        Console.WriteLine(manager.Report());
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
