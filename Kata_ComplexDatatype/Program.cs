using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OnlineOrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //EnterMainLoop();
        }

        static void EnterMainLoop()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("1: Order an electric bicycle");
                Console.WriteLine("2: Order a trampoline");
                Console.WriteLine("3: Order a bouquet");
                Console.WriteLine("4: Order something else");
                Console.WriteLine("5: Show all orders");
                Console.WriteLine("6: Show amount of each order");
                Console.WriteLine("7: Exit");

                Console.Write("Type option and press enter:");
                int choice = int.Parse(Console.ReadLine());

                Console.Clear();

                if (choice == 1)
                {
                    // lägg till ny beställning till listan
                }
                else if (choice == 2)
                {
                    // lägg till ny beställning till listan
                }
                else if (choice == 7)
                {
                    break;
                }
            }
        }
    }
}
