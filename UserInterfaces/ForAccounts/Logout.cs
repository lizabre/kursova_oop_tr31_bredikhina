using Kursova.Services;
using Kursova.UserInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.UserInterfaces.ForAccounts
{
    class Logout : ICommand
    {
        public ClientServices? ClientServices { get; set; }
        public CompanyServices? CompanyServices { get; set; }
        public string Name => "Logout";

        public Logout(ClientServices clientServices, CompanyServices companyServices) {
            CompanyServices = companyServices;
            ClientServices = clientServices;
        }
        public void Execute()
        {
            if (CompanyServices.GetCompany() != null)
            {
                CompanyServices.SetCompany(null);
            }
            else if (ClientServices.GetClient() != null) {
                ClientServices.changeClient(null);
            }
            State.IsChanged = true;
            Console.Clear();
        }
    }
}
