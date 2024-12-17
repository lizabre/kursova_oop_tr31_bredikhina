using Kursova.Accounts;
using Kursova.Services;
using Kursova.UserInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Kursova.UserInterfaces.ForAccounts
{
    class Login : ICommand
    {   
        public ClientServices ClientServices { get; set; }
        public CompanyServices CompanyServices { get; set; }
        public AccountServices AccountServices { get; set; }
        public string Name => "Login";
        public Login(AccountServices accountServices, ClientServices clientServices, CompanyServices companyServices)
        {
            AccountServices = accountServices;
            ClientServices = clientServices;
            CompanyServices = companyServices;
        }

        public void Execute()
        {
            PasswordHelper passwordHelper = new PasswordHelper();
            Console.Clear();
            string username, password;
            while (true)
            {
                Console.Write("Please enter your username/email:\n\t");
                username = Console.ReadLine();
                if (username != null)
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Please enter your password:\n\t");
                password = passwordHelper.ReadPassword();
                if (passwordHelper.IsCorrect(password))
                {
                    break;
                }
            }
            Account acc = AccountServices.Login(username, password);
            if(acc is Client)
            {
                ClientServices.changeClient(acc);
            }
            else
            {
                CompanyServices.SetCompany(acc);
            }
            State.IsChanged = true;
            Console.Clear();
        }

    }
}
