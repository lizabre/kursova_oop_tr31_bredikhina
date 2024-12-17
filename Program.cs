using Kursova.Accounts;
using Kursova.Accounts.Companies;
using Kursova.Repo;
using Kursova.Services;
using Kursova.Services.Interfaces;
using Kursova.UserInterfaces;
using Kursova.UserInterfaces.ForAccounts;
using Kursova.UserInterfaces.ForProducts;
using Kursova.UserInterfaces.ForProducts.ForClients;
using Kursova.UserInterfaces.ForProducts.ForCompanies;

namespace Kursova
{
    internal class Program
    {
        static public CommandManager SetCommandManager(AccountServices accountServices, ProductServices productServices, ClientServices? clientServices, CompanyServices? companyServices)
        {
            CommandManager commandManager = new CommandManager();
            if (clientServices.GetClient() == null && companyServices.GetCompany() == null)
            {
                commandManager.AddCommand(new Login(accountServices, clientServices, companyServices));
                commandManager.AddCommand(new Register(accountServices, clientServices, companyServices));
            }
            else
            {
                commandManager.AddCommand(new ShowAllProducts(productServices));
                //commandManager.AddCommand(new ShowUser(accountServices, productServices, ));
                if (clientServices.GetClient()!=null)
                {
                    commandManager.AddCommand(new ShowClient(clientServices));
                    commandManager.AddCommand(new AddToBasket(productServices, clientServices));
                    commandManager.AddCommand(new TakeFromBasket(productServices, clientServices));
                    commandManager.AddCommand(new BuyProduct(clientServices));
                }
                else
                {
                    commandManager.AddCommand(new ShowCompany(companyServices, productServices));
                    commandManager.AddCommand(new AddProduct(productServices, companyServices));
                    commandManager.AddCommand(new ShowCompanyProducts(productServices, companyServices));
                    commandManager.AddCommand(new DeleteProduct(productServices, companyServices));
                }
                commandManager.AddCommand(new Logout(clientServices, companyServices));
            }
            commandManager.AddCommand(new Exit());
            return commandManager;
        }
        static public void WorkingShop(AccountServices accountServices, ProductServices productServices, ClientServices clientServices, CompanyServices companyServices)
        {

            CommandManager commandManager = SetCommandManager(accountServices, productServices, clientServices, companyServices);
            while (true)
            {
                try
                {
                    if (State.IsChanged)
                    {
                        commandManager = SetCommandManager(accountServices, productServices, clientServices, companyServices);
                        State.IsChanged = false;
                    }
                    if (clientServices.GetClient()!=null)
                    {
                        Console.WriteLine("Hi, " + clientServices.GetClient().Username);
                    }
                    else if (companyServices.GetCompany() != null)
                    {
                        Console.WriteLine("Hi, " + companyServices.GetCompany().Username);
                    }
                    commandManager.ShowCommands();
                    commandManager.ChooseCommand();
                }
                catch (Exception ex)
                {
                }
            }

        }
        static void Main(string[] args)
        {
            DBContext dBContext = new DBContext();
            AccountRepo accountRepo = new AccountRepo(dBContext);
            ProductRepo productRepo = new ProductRepo(dBContext);
            AccountServices accountServices = new AccountServices(accountRepo);
            ProductServices productServices = new ProductServices(productRepo);
            ClientServices clientServices = new ClientServices();
            CompanyServices companyServices = new CompanyServices();
            CommandManager commandManager = SetCommandManager(accountServices, productServices, clientServices, companyServices);

            WorkingShop(accountServices, productServices, clientServices, companyServices);
        }
    }
}
