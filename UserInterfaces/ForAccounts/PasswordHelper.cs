using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kursova.UserInterfaces.ForAccounts
{
     class PasswordHelper
    {
        private Regex uppercaseCharacterMatcher = new Regex("[A-Z]");
        private Regex lowercaseCharacterMatcher = new Regex("[a-z]");
        private Regex digitMatcher = new Regex("[0-9]");

        public bool IsCorrect(string password)
        {
            return password != null && password.Length > 4 && uppercaseCharacterMatcher.Matches(password).Count >= 1 && lowercaseCharacterMatcher.Matches(password).Count >= 1 && digitMatcher.Matches(password).Count >= 1;
        }
        public string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring(0, password.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;
        }
    }
}
