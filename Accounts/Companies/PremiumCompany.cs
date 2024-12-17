using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Accounts.Companies
{
    class PremiumCompany : Company
    {
        public PremiumCompany(string _username, string _email, string _password) : base(_username, _email, _password)
        {
        }
        public override void AddTax()
        {
            this.Tax = 0.05;
        }
    }
}
