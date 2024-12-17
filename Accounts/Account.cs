using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Accounts
{
    enum AccountTypes
    {
        Client,
        RegularCompany,
        PremiumCompany,
        Undifined
    };
    abstract class Account
    {
        private static int accountID = 1;
        private int id;
        private string password;
        public int ID { get { return id; } }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get { return password; } }
        public Account(string _username, string _email, string _password)
        {
            id = accountID++;
            password = _password;
            Username = _username;
            Email = _email;
        }
    }
}
