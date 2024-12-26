using Kursova.Accounts.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Products
{
    enum ProductTypes{
        Usual,
        Discount, 
        Unassigned
    }
    class Product
    {
        private static int productID = 1;
        private int id;
        private string name;
        private string description;
        protected double initPrice;
        protected double price;
        private int quantity;
        private Company company;
        public int Id { get { return id; } }
        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public double Price { get { return price; } }
        public int Quantity { get { return quantity; } }
        public Company Company { get { return company; } }
        public Product(string _name, string _description, double _price, int _quantity, Company _company)
        {
            id = productID++;
            name = _name;
            description = _description;
            initPrice = _price;
            quantity = _quantity;
            company = _company;
            CountFinalPrice();
        }
        public virtual void CountFinalPrice()
        {
            price = initPrice * (1 + Company.Tax);
        }
        public void BeingBought(int q) {
            if (q <= 0)
            {
                throw new Exception("Cannot sell it");
            }
            quantity -= q;
        }
        public void CorrectQuantity(int q) {
            if (q < 0) {
                throw new Exception("Cannot put this value for product quantity");
            }
            quantity = q;
        }
        public override string ToString()
        {
            return "--------------" + Name + "--------------\n\t" + Description + "\n\t" + Quantity + "piece(s)\t" + Price + " uah\nFrom: " + Company.Username;
        }
        
    }
}
