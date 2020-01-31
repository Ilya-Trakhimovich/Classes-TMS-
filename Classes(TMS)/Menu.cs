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
                              " 4 - Show products of category" +
                              " 5 - Show total price of all products;" +
                              " 6 - Change product amount;" +
                              " 7 - Change product price;" +
                              " 8 - Exit.\n");
            Console.ResetColor();
        }

        public void Welcome()
        {
            Console.WriteLine("Hello! You are in the store. Let's start work with products!!!\n");
        }
    }
}
