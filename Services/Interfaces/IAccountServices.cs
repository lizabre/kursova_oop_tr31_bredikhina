using Kursova.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Services.Interfaces
{
    interface IAccountServices
    {
        Account Register(string username, string email, string password, AccountTypes type);
        Account Login(string username, string password);
        void Remove(Account account);
        void Remove(int id);
        Account? GetAccount(int id);
    }
}
