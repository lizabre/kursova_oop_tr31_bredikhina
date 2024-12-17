using Kursova.UserInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.UserInterfaces
{
    class CommandManager
    {
        public List<ICommand> Commands { get; }
        public CommandManager()
        {
            Commands = new List<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            if (command == null) throw new Exception("No command to add");
            Commands.Add(command);
        }
        public void ShowCommands()
        {
            if (Commands.Count == 0)
            {
                Console.WriteLine("No commands yet");
                return;
            }
            for (int i = 0; i < Commands.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + Commands[i].Name);
            }
        }
        public void ChooseCommand()
        {
            if (Commands.Count == 0)
            {
                Console.WriteLine("No commands yet");
                return;
            }
            while (true)
            {
                Console.WriteLine("Choose a command:");
                int answer;
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    if (answer > 0 && answer <= Commands.Count)
                    {
                        try
                        {
                            Commands[--answer].Execute();
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;
                    }
                }
            }
        }
    }
}
