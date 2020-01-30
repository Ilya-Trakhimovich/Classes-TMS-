using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_TMS_
{
    public class Store
    {
        private List<Product> _productList = new List<Product>();

        public void AddProduct(Product product)
        {
            _productList.Add(product);
        }

        public void ShowProducts()
        {
            for (var i = 0; i < _productList.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"ID: {_productList[i].id}, Name: {_productList[i].name}, Count: {_productList[i].amount}, Price: {_productList[i].price}$\n");
                Console.ResetColor();
            }
        }

        public void RemoveProduct()
        {          
            bool flagRemoveID = true;
            bool isRemoved = false;
            Product product = new Product();
            string productName = product.GetProductName(); 
            int productId = 0;

            while (flagRemoveID)
            {
                Console.Write("Enter product's ID: ");

                bool isCorrectID = Int32.TryParse(Console.ReadLine(), out productId);

                if (!isCorrectID)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ID is integer. Try again!\n");
                    Console.ResetColor();
                }
                else
                {
                    flagRemoveID = false;
                }
            }

            for (var i = 0; i < _productList.Count; i++)
            {
                if (_productList[i].name == productName && _productList[i].id == productId)
                {
                    _productList.Remove(_productList[i]);
                    Console.WriteLine("Product remooved.\n");
                    isRemoved = true;
                }
            }

            if (!isRemoved)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error. Name or ID isn't correct. If you dont know product's NAME and ID open list of products.\n");
                Console.ResetColor();
            }
        }

        public void GetTotalPrice()
        {
            double totalPrice = 0;

            for (var i = 0; i < _productList.Count; i++)
            {
                totalPrice += (_productList[i].price * _productList[i].amount);
            }

            Console.WriteLine($"Total price: {totalPrice}$\n");
        }
    }
}
