using System;
using System.Collections.Generic;
using System.Globalization;

using System.Threading.Tasks;

namespace StoreInterface
{
    class Program
    {
        
        static private Tshirt[] AllTshirts;
        static private Muggar[] muggar;
        

        static void Main(string[] args)
        {
            List<string> menuItems;
            string besöksadress = "Skutskärs centreum 81430";
            string fakturering= "Skutskärs centreum";
            Console.WriteLine(" Skutskärs butik:{0},Skutskärs butik:{0}", besöksadress);
            Console.WriteLine("Initializing...");
            Initialize();
            menuItems = new List<string>
            {
                "Enter Store",
                "Exit"
            };


            bool isRunning = true;
            while (isRunning)                              
            {
                menuItems = Menu.Draw(menuItems, out isRunning);
            }
         /*  Console.WriteLine("----List of Muggar----");
            foreach (Muggar m in muggar)
            {
                Console.WriteLine(m.ToString());
            }
            Console.WriteLine("----List of Tshirt----");
            foreach (Tshirt m in AllTshirts)
            {
                Console.WriteLine(m.ToString());
            }*/
        }

        public static void Initialize()
        {
            AllTshirts = Tshirt.generateTshirt();
            AllTshirts = Tshirt.sort1(AllTshirts);

            muggar = Muggar.generateMuggar();
            muggar = Muggar.sort1(muggar);

        }
        public static Tshirt[] GetTshirts()
        {
            return AllTshirts;
        }
        public static Muggar[] Getmuggars()
        {
            Muggar[]  a= Muggar.sort1(muggar);

            return a;
        }
    }
}