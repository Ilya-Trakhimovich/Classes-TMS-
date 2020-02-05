using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDLL
{
    public class Product
    {
        public string name;
        public string category;
        public double price;
        public double amount;
        public static int sID = 1;
        public int id;

        public Product() { }
        public Product(string name, string category) : this(name, category, 0) { }
        public Product(string name, string category, double price) : this(name, category, price, 0) { }

        public Product(string name, string category, double price, double amount)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.amount = amount;
            id = sID;
            sID++;
        }

        public Product GetProduct()
        {
            string productName = GetProductName();
            string productCategory = GetProductCategory();
            double productPrice = GetProductPrice();
            double productCount = GetProductAmount();

            Product newProduct = new Product(productName, productCategory, productPrice, productCount);

            return newProduct;
        }

        public string GetProductName()
        {
            bool flagName = true;
            string productName = "";

            while (flagName)
            {
                Console.Write("Product's name: ");
                productName = Console.ReadLine();

                if (string.IsNullOrEmpty(productName) || string.IsNullOrWhiteSpace(productName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name can not be null or emtpry. Try again!\n");
                    Console.ResetColor();
                }
                else
                {
                    flagName = false;
                }
            }

            return productName;
        }

        public string GetProductCategory()
        {
            bool flagName = true;
            string productCategory = "";

            while (flagName)
            {
                Console.Write("Product's category: ");
                productCategory = Console.ReadLine();

                if (string.IsNullOrEmpty(productCategory) || string.IsNullOrWhiteSpace(productCategory))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Category can not be null or emtpry. Try again!\n");
                    Console.ResetColor();
                }
                else
                {
                    flagName = false;
                }
            }

            return productCategory;
        }

        public double GetProductPrice()
        {
            bool flagPrice = true;
            double productPrice = 0;

            while (flagPrice)
            {
                Console.Write("Price: ");

                bool isCorrectPrice = double.TryParse(Console.ReadLine(), out productPrice);

                if (isCorrectPrice && productPrice > 0)
                {
                    flagPrice = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Price has double format. Price cannot be negative and equls to 0. Try again!\n");
                    Console.ResetColor();
                }
            }

            return productPrice;
        }

        public double GetProductAmount()
        {
            bool flagAmount = true;
            double productAmount = 0;

            while (flagAmount)
            {
                Console.Write("Amount: ");

                bool isCorrectAmount = double.TryParse(Console.ReadLine(), out productAmount);

                if (isCorrectAmount && productAmount >= 0)
                {
                    flagAmount = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Amount has double format. Amount cannot be negative. Try again!\n");
                    Console.ResetColor();
                }
            }

            return productAmount;
        }
    }
}

