using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Accounts.Companies
{
    abstract class Company : Account
    {
        public double Tax { get; set; }
        public Company(string _username, string _email, string _password) : base(_username, _email, _password)
        {
        }
        abstract public void AddTax();
    }
}
