﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.UserInterfaces.Interfaces
{
    interface ICommand
    {
        string Name { get; }
        void Execute();
    }
}
