using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_TMS_
{
    public class Product
    {
        public string name;
        public int price;
        public int count;
        public Guid id;

        public Product() { }
        public Product(string name) : this(name, 0) { }
        public Product(string name, int price) : this(name, price, 0) { }

        public Product(string name, int price, int count)
        {
            this.name = name;
            this.price = price;
            this.id = Guid.NewGuid();
            this.count = count;
        }

        public Product SetProduct()
        {
            Console.Write("Name: ");
            string productName = Console.ReadLine();

            Console.Write("Price: ");
            int productPrice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Count: ");
            int productCount = Convert.ToInt32(Console.ReadLine());

            Product newProduct = new Product(productName, productPrice, productCount);

            return newProduct;
        }
    }
}
