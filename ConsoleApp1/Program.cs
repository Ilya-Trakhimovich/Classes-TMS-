using System;

namespace ConsoleApp1
{
    class Program
    {
        public static int Item()
        {
            int i = 2;
            bool[] activeMenuIndex = new bool[5];
            Console.WriteLine("Используйте стрелки вверх, вниз для перемешения по пунктам меню");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("   * создание случайных чисел для одномерного массива");
            Console.WriteLine("   * создание случайных чисел для двумерного массива");
            Console.WriteLine("   * вывод всех массивов на экран консоли");
            Console.WriteLine("   * создать IO stream");
            Console.WriteLine("   * выход из консольного приложения");
            Console.SetCursorPosition(0, i);
            Console.Write("=>");

            ConsoleKey key = Console.ReadKey().Key;

            while (key != ConsoleKey.Escape)
            {
                Console.SetCursorPosition(0, 8);
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (i > 2)
                            {
                                i--;
                                Console.SetCursorPosition(0, i);
                                Console.Write("=>");
                                Console.SetCursorPosition(0, i + 1);
                                Console.Write("  ");
                            }
                            break;

                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (i < 6)
                            {
                                i++;
                                Console.SetCursorPosition(0, i);
                                Console.Write("=>");
                                Console.SetCursorPosition(0, i - 1);
                                Console.Write("  ");
                            }
                            break;

                        }
                    case ConsoleKey.Enter:
                        return i;
                }
            }

            return i;
        }

        static void Main(string[] args)
        {
            
            
            int i = Item();

            if (i > 1 && i < 10)
            {
                Console.WriteLine("gdfgdfg");
            }            
        }
    }
}
