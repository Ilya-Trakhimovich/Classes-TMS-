using System;

namespace ConsoleApp2
{
    class Program
    {
        class MyClass
        {
            public int Prop { get; } =111111110;
        }

        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            Console.WriteLine(mc.Prop);
        }
    }
}
