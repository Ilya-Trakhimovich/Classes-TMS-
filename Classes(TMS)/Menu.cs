using System;

namespace Classes_TMS_

{
    public class Menu
    {
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1 - Add product;" +
                              " 2 - Remove product;" +
                              " 3 - Show list of products;" +
                              " 4 - Show total price of all products;" +
                              " 5 - Change product amount;" +
                              " 6 - Change product price;" +
                              " 7 - Exit.\n");
            Console.ResetColor();
        }

        public void Welcome()
        {
            Console.WriteLine("Hello! You are in the store. Let's start with products!!!\n");
        }
    }
}
