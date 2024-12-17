using Kursova.UserInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.UserInterfaces
{
    class Exit : ICommand
    {
        public string Name => "Exit";

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
