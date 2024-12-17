using Kursova.Accounts.Companies;
using Kursova.Accounts;
using Kursova.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Kursova.Repo;

namespace Kursova.Services
{
    class AccountServices : IAccountServices
    {
        private readonly AccountRepo accountRepo;
        public AccountServices(AccountRepo accountRepo)
        {
            this.accountRepo = accountRepo;
        }

        public Account Register(string username, string email, string password, AccountTypes type)
        {
            if (username == "" || email == "" || password == "" || type ==AccountTypes.Undifined)
            {
                throw new Exception("The account is null! Please provide a valid account");
            }
            AccountFactory accountFactory = new AccountFactory();
            Account acc = accountFactory.GetAccount(type, username, email, password);
            if (accountRepo == null)
            {
                throw new Exception("Error connecting with a database");
            }
            if (accountRepo.GetAccountByUserNameOrEmail(username) != null|| accountRepo.GetAccountByUserNameOrEmail(email) != null)
            {
                throw new Exception("Account already exists!");
            }
            accountRepo.Add(acc);
            return acc;
        }

        public Account Login(string username, string password)
        {
            if (username == "" || password == "")
            {
                throw new Exception("Input(s) is(are) empty!");
            }
            Account acc = accountRepo.GetAccountByUserNameOrEmail(username);
            if (acc == null)
            {
                throw new Exception("No such user found!");
            }
            if (acc.Password != password)
            {
                throw new Exception("Password is wrong!");
            }
            return acc;
        }

        public Account? GetAccount(int id)
        {
            if (id < 0 || id >= accountRepo.GetAccountCount())
            {
                throw new Exception("Wrong id!");
            }
            return accountRepo.GetAccount(id);
        }

        public void Remove(Account account)
        {
            if (account == null)
            {
                throw new Exception("The account is null! Please provide a valid account");
            }
            if (accountRepo.GetAccount(account.ID) == null)
            {
                throw new Exception("No such account in the database");
            }
            accountRepo.Remove(account);
        }
        public void Remove(int id)
        {
            if (id < 0 || id >= accountRepo.GetAccountCount())
            {
                throw new Exception("Wrong id!");
            }
            if (accountRepo.GetAccount(id) == null)
            {
                throw new Exception("No account at this id");
            }
            accountRepo.Remove(id);
        }
    }
}
