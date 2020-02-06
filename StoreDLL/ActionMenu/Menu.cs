using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDLL
{
    public class Menu
    {
        private const string _arrow = "--> ";
        private readonly string[] _menu =
            {
                "  Add product;",
                "  Remove product;",
                "  Show products of category",
                "  Show total price of all products;",
                "  Change product amount;",
                "  Change product price;",
                "  Exit."
            };

        private void Welcome(Store store)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\t\t\t { DateTime.Now}");            
            Console.WriteLine(new string('_', 100));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\t\t\tCONSOLE APPLICATION MENU\n");
            Console.WriteLine(new string('_', 100));

            Store tempStore = store;

            tempStore.ShowProducts();
        }

        private void MoveArrow(int moveChoice, Store store)
        {
            Console.Clear();

            Welcome(store);
           
            for (var i = 0; i < _menu.Length; i++)
            {
                if (i == moveChoice)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(_arrow);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(_menu[i]);
            }
        }

        public int ShowMenu(Store store)
        {
            int choice = 0;
            Console.CursorVisible = false;

            while (true)
            {
                MoveArrow(choice, store);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (choice != 0)
                            {
                                --choice;
                            }

                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (choice != _menu.Length - 1)
                            {
                                ++choice;
                            }

                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            Console.ResetColor();

                            return choice;
                        }                                                                    
                }
            }
        }                         
    }
}
