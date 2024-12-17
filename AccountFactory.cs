using Kursova.Accounts;
using Kursova.Accounts.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova
{
    internal class AccountFactory
    {
        public Account GetAccount(AccountTypes type, string username, string email, string password)
        {
            switch (type) {
                case AccountTypes.Client: return new Client(username, email, password);
                case AccountTypes.RegularCompany: return new RegularCompany(username, email, password);
                case AccountTypes.PremiumCompany: return new PremiumCompany(username, email, password);
                default: return null;
            }
        }
    }
}
