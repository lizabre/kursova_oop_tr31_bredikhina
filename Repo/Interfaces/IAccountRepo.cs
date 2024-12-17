using Kursova.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Repo.Interfaces
{
    interface IAccountRepo
    {
        public void Add(Account account);
        public void Remove(Account account);
        public void Remove(int id);
        Account? GetAccount(int id);
        Account? GetAccountByUserNameOrEmail(string name);
        public List<Account> GetAccounts();
        public int GetAccountCount();
    }
}
