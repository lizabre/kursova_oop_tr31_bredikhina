using Kursova.Accounts;
using Kursova.Products;
using Kursova.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova
{
    static class State
    {
        public static bool IsChanged { get; set; } = false;
    }
}
