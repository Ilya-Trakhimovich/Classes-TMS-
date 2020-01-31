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
                new Product("shrimp", "seafood", 19, 15),
                new Product("chiken fillet", "meat", 15, 50),
                new Product("apple juice", "juice"),
                new Product("seeds", "grocery", 1, 150),
                new Product("beer", "alcohol", 21, 219),
                new Product("apple", "fruits", 4),
                new Product("oil", "grocery"),
                new Product("beef", "meat", 20, 350),
                new Product("sea fish", "seafood", 20),
                new Product("minced pork", "meat"),
                new Product("Bananas", "frutis", 200, 14)
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
                    case (int)MenuAction.AddProduct:
                        {
                            var product = new Product();

                            product = product.GetProduct(); // Returns new product.
                            store.AddProduct(product);

                            break;
                        }
                    case (int)MenuAction.RemoveProduct:
                        {
                            store.RemoveProduct();

                            break;
                        }
                    case (int)MenuAction.ShowProducts:
                        {
                            store.ShowProducts();

                            break;
                        }
                    case (int)MenuAction.ShowCategory:
                        {
                            store.ShowCategory();

                            break;                        
                        }
                    case (int)MenuAction.TotalPrice:
                        {
                            store.GetTotalPrice();

                            break;
                        }
                    case (int)MenuAction.ChangeProductAmount:
                        {
                            store.ChangeProductAmount();

                            break;
                        }
                    case (int)MenuAction.ChangeProductPrice:
                        {
                            store.ChangeProductPrice();

                            break;
                        }
                    case (int)MenuAction.Exit:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
    }
}
