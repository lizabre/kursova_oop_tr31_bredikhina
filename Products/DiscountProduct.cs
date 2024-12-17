using Kursova.Accounts.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Products
{
    class DiscountProduct : Product
    {
        private string discount_reason;
        private double discount;
        public string Discount_reason { get { return discount_reason; } }
        public double Discount { get { return discount; } }
        public DiscountProduct(string _name, string _description, double _price, int _quantity, Company _company, string _discount_reason, double _discount) : base(_name, _description, _price, _quantity, _company)
        {
            discount = _discount;
            discount_reason = _discount_reason;
        }
        public override void CountFinalPrice()
        {
            price = initPrice * (1 - Company.Tax - Discount);
        }
    }
}
