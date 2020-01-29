using System;

namespace Classes_TMS_
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();
            Store store = new Store();
            bool flag = true;

            while (flag)
            {
                menu.ShowMenu();

                bool isChoice = Int32.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case (int)Action.AddProduct:
                        {
                            var product = new Product();
                            product = product.SetProduct(); // Returns new product.

                            store.AddProduct(product);

                            break;
                        }
                    case (int)Action.DeleteProduct:
                        {
                            break;
                        }
                    case (int)Action.ShowProducts:
                        {
                            store.ShowProducts();

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
