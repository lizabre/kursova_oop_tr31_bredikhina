using Kursova.Accounts;
using Kursova.Accounts.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Services
{
    internal class CompanyServices
    {
        private Company? company = null;
        public CompanyServices() { }
        public void SetCompany(Account company)
        {
            this.company = (company as Company);
        }
        public Company? GetCompany()
        {
            return company;
        }
    }
}
