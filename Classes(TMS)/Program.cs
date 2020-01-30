using System;
using System.Collections.Generic;

namespace Classes_TMS_
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Store store = new Store();
            bool flag = true;

            menu.Welcome();

            var listProduct = new List<Product>()
            {
                new Product("fish", 19, 15),
                new Product("meat", 15, 50),
                new Product("juice"),
                new Product("chips", 1, 150),
                new Product("beer", 21, 219),
                new Product("apple", 4),
                new Product("oil"),
                new Product("pizza", 20, 350)             
            };

            for (var i = 0; i < listProduct.Count; i++)
            {
                store.AddProduct(listProduct[i]);
            }

            while (flag)
            {
                menu.ShowMenu();

                bool isChoice = Int32.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case (int)Action.AddProduct:
                        {
                            var product = new Product();

                            product = product.GetProduct(); // Returns new product.
                            store.AddProduct(product);

                            break;
                        }
                    case (int)Action.RemoveProduct:
                        {
                            store.RemoveProduct();

                            break;
                        }
                    case (int)Action.ShowProducts:
                        {
                            store.ShowProducts();

                            break;
                        }
                    case (int)Action.TotalPrice:
                        {
                            store.GetTotalPrice();

                            break;
                        }
                    case (int)Action.ChangeProductAmount:
                        {
                            store.ChangeProductAmount();

                            break;
                        }
                    case (int)Action.ChangeProductPrice:
                        {
                            store.ChangeProductPrice();

                            break;
                        }
                    case (int)Action.Exit:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
    }
}
