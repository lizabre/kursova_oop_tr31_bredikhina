using Kursova.Accounts;
using Kursova.Services;
using Kursova.UserInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kursova.UserInterfaces.ForAccounts
{
    class Register : ICommand
    {
        public ClientServices ClientServices { get; set; }
        public CompanyServices CompanyServices { get; set; }
        public AccountServices AccountServices { get; set; }

        public string Name => "Register";

        public Register(AccountServices accountServices, ClientServices clientServices, CompanyServices companyServices)
        {
            AccountServices = accountServices;
            ClientServices = clientServices;
            CompanyServices = companyServices;
        }

        public void Execute()
        {
            Console.Clear();
            string name, email, password;
            AccountTypes type = AccountTypes.Undifined;
            PasswordHelper passwordHelper = new PasswordHelper();
            while (true)
            {
                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Welcome! Please enter your username [at least 3 symbols]:\n\t");

                name = Console.ReadLine();
                if (name != null && name.Length > 3)
                {
                    break;
                }
            }
            while (true)
            {
                Console.Write("Please enter your valid email:\n\t");
                email = Console.ReadLine();
                if (email != null && email.Contains('@'))
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
            while (true)
            {
                int ans = 0;
                Console.WriteLine("Please choose who you are:\n[1]-Client \t\t [2] - Company");
                if (int.TryParse(Console.ReadLine(), out ans))
                {
                    switch (ans)
                    {
                        case 1: type = AccountTypes.Client; break;
                        case 2:
                            {
                                while (true)
                                {

                                    Console.WriteLine("What company do you want to represent? (Premium companies need to provide official documentation and have lesser tax percentage)\n[1] - Regular \t\t [2] - Premium");
                                    if (int.TryParse(Console.ReadLine(), out ans))
                                    {
                                        if (ans == 1)
                                        {
                                            type = AccountTypes.RegularCompany;
                                            break;
                                        }
                                        else if (ans == 2)
                                        {
                                            type = AccountTypes.PremiumCompany;
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        default: break;
                    }
                }
                if (type != AccountTypes.Undifined)
                {
                    break;
                }
            }
            Account acc = AccountServices.Register(name, email, password, type);
            if(type == AccountTypes.Client)
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

