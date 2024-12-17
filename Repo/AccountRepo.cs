using Kursova.Accounts;
using Kursova.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Repo
{
    class AccountRepo : IAccountRepo
    {
        private readonly DBContext dBContext;
        public AccountRepo(DBContext context)
        {
            dBContext = context;
        }
        public void Add(Account account)
        {
           dBContext.Accounts.Add(account);
        }

        public Account? GetAccount(int id)
        {
            return dBContext.Accounts[id];
        }

        public Account? GetAccountByUserNameOrEmail(string name)
        {
           return dBContext.Accounts.Find(acc => acc.Username == name || acc.Email == name);
        }

        public int GetAccountCount()
        {
            return dBContext.Accounts.Count;
        }

        public List<Account> GetAccounts()
        {
            return dBContext.Accounts;
        }

        public void Remove(Account account)
        {
            dBContext.Accounts.Remove(account);
        }

        public void Remove(int id)
        {
            dBContext.Accounts.RemoveAt(id);
        }
    }
}
