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
                              " 5 - Exit.\n");
            Console.ResetColor();
        }
    }
}
