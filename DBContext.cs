using Kursova.Accounts.Companies;
using Kursova.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursova.Products;

namespace Kursova
{
    class DBContext
    {
        public List<Account> Accounts = new List<Account>();
        public List<Product> Products = new List<Product>();
        public DBContext()
        {
            List<Account> temp_acc = new List<Account>{ new RegularCompany("TechSolutions", "contact@techsolutions.com", "SecurePass123"),
            new RegularCompany("GreenEarth", "info@greenearth.org", "EcoFriendly2024"),
            new RegularCompany("SmartHomes", "support@smarthomes.net", "HomeTech456"),
            new RegularCompany("QuickDelivery", "service@quickdelivery.com", "FastTrack789"),
            new RegularCompany("EduLearn", "admin@edulearn.edu", "LearnNow321"),
            new RegularCompany("HealthPlus", "care@healthplus.com", "HealthyLife123"),
            new RegularCompany("AutoDrive", "team@autodrive.ai", "DriveSafe2024"),
            new RegularCompany("TravelWise", "hello@travelwise.com", "Explore2024"),
            new RegularCompany("FoodieHub", "contact@foodiehub.com", "TastyTreats456"),
             new RegularCompany("BrightIdeas", "ideas@brightideas.net", "Innovate2024"),
            new PremiumCompany("EliteTech", "premium@elitetech.com", "LuxuryPass123"),
            new PremiumCompany("GoldenEarth", "vip@goldenearth.org", "EcoElite2024"),
            new PremiumCompany("LuxuryHomes", "contact@luxuryhomes.net", "SafeHaven456"),
            new PremiumCompany("PrimeDelivery", "vip@primedelivery.com", "ExpressPlus789"),
            new PremiumCompany("EduElite", "support@eduelite.edu", "LearnElite321"),
            new PremiumCompany("HealthPro", "premium@healthpro.com", "WellnessPlus123"),
            new PremiumCompany("AutoPrime", "vip@autoprime.ai", "DrivePrime2024"),
            new PremiumCompany("LuxuryTravel", "vip@luxurytravel.com", "ExplorePrime2024"),
            new PremiumCompany("GourmetHub", "vip@gourmethub.com", "FineDine456"),
             new PremiumCompany("VisionaryIdeas", "vip@visionaryideas.net", "InnoPrime2024"),
            new Client("JohnDoe", "john.doe@example.com", "Password123"),
            new Client("JaneSmith", "jane.smith@example.com", "SecurePass456"),
            new Client("AlexBrown", "alex.brown@example.com", "Welcome789"),
            new Client("ChrisJohnson", "chris.johnson@example.com", "ClientPass321"),
            new Client("PatTaylor", "pat.taylor@example.com", "TaylorSafe2024"),
            new Client("JordanLee", "jordan.lee@example.com", "LeeSecure123"),
            new Client("MorganWhite", "morgan.white@example.com", "WhitePass456"),
            new Client("CaseyGreen", "casey.green@example.com", "GreenAccess789"),
            new Client("JamieClark", "jamie.clark@example.com", "ClarkSecure321"),
             new Client("DanaCarter", "dana.carter@example.com", "CarterSafe2024")
            };
            Accounts.AddRange(temp_acc);

            List<Product> products = new List<Product> {
                new Product("Laptop", "High-performance laptop with 16GB RAM", 1200.50, 10, Accounts[0] as Company),
                new Product("Smartphone", "5G-enabled smartphone with 128GB storage", 899.99, 25, Accounts[2] as Company),
                new Product("Headphones", "Noise-cancelling over-ear headphones", 199.99, 50, Accounts[0] as Company),
                new Product("Gaming Console", "Latest generation gaming console", 499.99, 15, Accounts[0] as Company),
                new Product("Smartwatch", "Water-resistant smartwatch with health tracking", 249.99, 30, Accounts[0] as Company),
                new Product("Tablet", "10-inch tablet with 64GB storage", 329.99, 20, Accounts[0] as Company),
                new Product("Monitor", "27-inch 4K UHD monitor", 349.99, 12, Accounts[0] as Company),
                new Product("Keyboard", "Mechanical RGB gaming keyboard", 99.99, 40, Accounts[0] as Company),
                new Product("Mouse", "Wireless ergonomic mouse", 49.99, 60, Accounts[0] as Company),
                new Product("Printer", "All-in-one color printer with Wi-Fi", 159.99, 8, Accounts[0] as Company),
                new Product("Desk Chair", "Ergonomic desk chair with lumbar support", 189.99, 15, Accounts[0] as Company),
                new Product("External Hard Drive", "2TB USB 3.0 external hard drive", 79.99, 35, Accounts[0] as Company),
                new Product("Router", "Wi-Fi 6 router with extended range", 129.99, 18, Accounts[0] as Company),
                new Product("Webcam", "1080p HD webcam for video calls", 69.99, 22, Accounts[0] as Company),
                new Product("Smart Bulb", "Wi-Fi-enabled smart bulb with color control", 19.99, 100, Accounts[0] as Company),
                new Product("Portable Charger", "10,000mAh power bank with fast charging", 39.99, 45, Accounts[0] as Company),
                new Product("Bluetooth Speaker", "Portable waterproof Bluetooth speaker", 89.99, 28, Accounts[0] as Company),
                new Product("Fitness Tracker", "Fitness tracker with heart rate monitor", 59.99, 50, Accounts[0] as Company),
                new Product("Flash Drive", "64GB USB 3.0 flash drive", 12.99, 150, Accounts[0] as Company),
                new Product("Electric Kettle", "1.7L electric kettle with temperature control", 49.99, 25, Accounts[0] as Company)};
            Products.AddRange(products);
        }
    }
}
