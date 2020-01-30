using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_TMS_
{
    public class Product
    {
        public string name;
        public double price;
        public double amount;
        public static int sID = 1;
        public int id;

        public Product() { }
        public Product(string name) : this(name, 0) { }
        public Product(string name, double price) : this(name, price, 0) { }

        public Product(string name, double price, double amount)
        {
            this.name = name;
            this.price = price;
            this.amount = amount;
            id = sID;
            sID++;
        }

        public Product GetProduct()
        {
            string productName = GetProductName();

            double productPrice = GetProductPrice();

            double productCount = GetProductAmount();

            Product newProduct = new Product(productName, productPrice, productCount);

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

        public double GetProductPrice()
        {
            bool flagPrice = true;
            double productPrice = 0;

            while (flagPrice)
            {
                Console.Write("Price: ");

                bool isCorrectPrice = double.TryParse(Console.ReadLine(), out productPrice);

                if (isCorrectPrice)
                {
                    flagPrice = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Price has double format. Try again!\n");
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

                if (isCorrectAmount)
                {
                    flagAmount = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Amount has double format. Try again!\n");
                    Console.ResetColor();
                }
            }

            return productAmount;
        }    
    }
}
