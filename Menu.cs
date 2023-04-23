using System;
using System.Collections.Generic;

namespace StoreInterface
{
    public class Menu
    {

        private static int _index = 1;                                                  
        static readonly string _fakturaAdress = "Skutskärs centreum";                        
        static readonly string _besoksAdress = "Skutskärs centreum 81430";                                  

        public static List<string> Draw(List<string> MenuItems, out bool isRunning)     
        {
            isRunning = true;

            Muggar[] muggars = Program.Getmuggars();                               
            Tshirt[] Tshirts = Program.GetTshirts();                                

            _index = 0;                                                                 
                                                                                       
                                                                                      
            while (isRunning)
            {


                string selectedMenuItem = DrawMenu(MenuItems);
                                 

                switch (selectedMenuItem)                                               
                {
                    case "Enter Store":                                                 
                        {
                            _index = 1;
                            Console.WriteLine();
                            MenuItems = new List<string>
                            {
                                "-|- Hello, and welcome to Skutskärs butik.-|- \r\n" +
                                $"-|- You can find us at {_besoksAdress}                                   -|-\r\n" +
                                $"-|- And billing at {_fakturaAdress}                              -|-\r\n",
                                "Tshirt",
                                "Mugger",
                                "Exit"
                            };
                            break;
                        }
                    case "Tshirt":                                                     
                        {
                            _index = 1;
                            MenuItems = new List<string>
                            {
                                "-|-  Select Yes to view our current stock of Goods. No to return to the main menu. -|-\r\n",
                                "Yes",
                                "No",
                            };
                            bool tshirtsLoop = true;
                            bool looped = false;
                            while (tshirtsLoop)                                          
                            {                                                          
                                selectedMenuItem = Menu.TshirtLoop(selectedMenuItem, MenuItems, out MenuItems, Tshirts.ToList(), out tshirtsLoop, looped, out looped);
                            }
                            MenuItems = new List<string>                                
                            {
                                "-|- Please make a new selection. -|-\r\n",
                                "Tshirt",
                                "Mugger",
                                "Exit"
                            };
                            _index = 1;
                            break;
                        }
                    case "Mugger":                                                     
                        {
                            _index = 0;
                            MenuItems = new List<string>();
                            foreach (Muggar m in muggars)                             
                            {
                                MenuItems.Add(m.Motiv + " Snittbetyg: " + Math.Round(m.Snittbetyg
                                    ));
                            }

                            bool muggLoop = true;

                            while (muggLoop)                                          
                            {
                                selectedMenuItem = MuggsLoop(selectedMenuItem, MenuItems, out MenuItems, muggars.ToList(), out muggLoop);
                            }

                            _index = 0;
                            Console.WriteLine("\r\nPress the any key (enter) to continue."); Console.SetWindowPosition(0, 0); Console.ReadLine();
                            Console.Clear();
                            MenuItems = new List<string>                                
                            {
                                "-|- Please make a new selection. -|-\r\n",
                                "Tshirt",
                                "Mugger",
                                "Exit"
                            };
                            _index = 2;
                            break;
                        }
                    case " Exit":                                                       
                        {                                                               
                            isRunning = false;                                          
                            _index = 0;
                            Console.Clear();                                            
                            Console.ForegroundColor = ConsoleColor.DarkYellow;          
                            Console.WriteLine("-|-Thank you for visiting our shop!\r\nPlease come visit us in person to buy some of our amazing goods!\r\nHave a nice day!");
                            Console.Read();                                             
                            break;
                        }   
                    case "Exit":                                                       
                        {
                            isRunning = false;
                            _index = 0;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("-|-Thank you for visiting our shop!\r\nPlease come visit us in person to buy some of our amazing goods!\r\nHave a nice day!");
                            Console.Read();
                            break;
                        }
                    default:                                                            
                        {
                            break;
                        }
                }
            }
            return MenuItems;                                                        
        }

       

        private static string TshirtLoop(string selectedMenuItem,List<string> MenuItems, out List<string> MenuItemsOut, List<Tshirt> tshirtList, out bool tshirtLoop, bool looped, out bool loopy)
        {                                                                              
            loopy = looped;                                                             
            tshirtLoop = true;
            if (!looped)                                                               
                selectedMenuItem = DrawMenu(MenuItems);

            if (selectedMenuItem.Contains('Y'))                                         
            {                                                                         
                _index = 0;
                MenuItems = new List<string>();
                foreach (Tshirt a in tshirtList)                                          
                {
                    MenuItems.Add(a.Motiv+ " Snittbetyg: " + Math.Round(a.Snittbetyg));
                }

                Console.ForegroundColor = ConsoleColor.Yellow;                          

                bool yesLoop = true;
                while (yesLoop)                                                        
                {
                    selectedMenuItem = DrawMenu(MenuItems);
            
                    foreach (Tshirt a in tshirtList)
                    {
                        if (a.Motiv +""+ " Snittbetyg: " + Math.Round(a.Snittbetyg) == selectedMenuItem)                              
                        {                                                               
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(a.ToString());
                           
                            yesLoop = false;                                           
                        }
                    }
                }
                _index = 0;
                Console.WriteLine("\r\nPress the any key (enter) to continue."); Console.SetWindowPosition(0,0); Console.ReadLine();
                Console.Clear();                                                        

                MenuItems = new List<string>                                            
                                    {
                                        " Would you like to read information from another Tshirt? -|-\r\n",
                                        "Yes",
                                        "No"
                                    };
                bool repeat = true;
                _index = 1;
                while (repeat)                                                          
                {
                    selectedMenuItem = DrawMenu(MenuItems);
           
                    if ((selectedMenuItem.Contains('N')) | selectedMenuItem.Contains('Y'))
                        repeat = false; loopy = true;
                    if (selectedMenuItem.Contains('N'))
                    {
                        tshirtLoop = false;
                        _index = 1;
                    }
                }
            }
            else if (selectedMenuItem.Contains('N'))
            {
                tshirtLoop = false;
                _index = 1;
            }

            MenuItemsOut = MenuItems;                                                   
            return selectedMenuItem;                                                    
        }                                                                              
                                                                                       
        private static string MuggsLoop(string selectedMenuItem, List<string> MenuItems, out List<string> MenuItemsOut, List<Muggar> mugglist, out bool muggsLoop )
        {
            selectedMenuItem = DrawMenu(MenuItems);
           
            muggsLoop = true;
            Console.ForegroundColor = ConsoleColor.Blue;

            foreach (Muggar m in mugglist)                                             
            {
                String s = m.Motiv + " Snittbetyg: " + Math.Round(m.Snittbetyg);
                if (s == selectedMenuItem)
                {
                    Console.Clear();
                    Console.WriteLine(m.ToString());
                    muggsLoop = false;
                }
            }
            MenuItemsOut = MenuItems;                                                  
            return selectedMenuItem;
        }

        public static bool Init(List<string> MenuItems)                                 
        {
            string selectedMenuItem = DrawMenu(MenuItems);
            
            if (selectedMenuItem == MenuItems[1])
            { 
                return true; 
            }
            else if (selectedMenuItem == MenuItems[2])
            { 
                return false; 
            }
            else 
            { 
                return Menu.Init(MenuItems);                                            
            }                                                                           
        }

        private static string DrawMenu(List<string> items)                              
        {                                                                               
            Console.Clear();
            Console.WriteLine(" Welcome to our store,\n For visit store click on Enter or click on Exit,\n After visit the store select the category, After that select the product");          

                for (int i = 0; i < items.Count; i++)                                       
            { 
                if (i == _index)                                                         
                {

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);

                }
                else                                                                    
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(items[i]);


                }
                Console.ResetColor();
            }

            Console.SetWindowPosition(0, Math.Max(_index - 3, 0));

            ConsoleKeyInfo ckey = Console.ReadKey();                                   

            if (ckey.Key == ConsoleKey.DownArrow)                                       
            {
                if (_index == items.Count - 1)
                {

                }
                else
                {
                    _index++;                                                            
                }                                                                       
            }

            else if (ckey.Key == ConsoleKey.UpArrow)                                   
            {
                if (_index <= 0)
                {

                }
                else
                {
                    _index--;                                                            
                }
            }
            else if (ckey.Key == ConsoleKey.Enter)                                      
            {
                if (_index < items.Count)
                    return items[_index];
                else
                    return items[items.Count - 1];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }
    }
}
