using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace numerikus_billentyu_kigyo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool kilepes = false;
            int s = 8; // állapot
            char head = '@';
            Console.CursorVisible = false;
            int x = Console.WindowWidth / 2;
            int y = Console.WindowHeight / 2;
            int kulso = Console.WindowWidth;
            int also = Console.WindowHeight;
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write(head);
            ConsoleKeyInfo k = new ConsoleKeyInfo();
            bool rossz = false;
            do
            {
                if (kilepes == false)
                {
                    if (Console.KeyAvailable)
                        k = Console.ReadKey(true);
                    switch (k.Key) //gomb megnézése
                    {
                        case ConsoleKey.NumPad8: //felnumpad( felfelé irányítás)
                            if (s != 8)
                            {
                                s = 8;
                            }
                            rossz = false;
                            break;
                        case ConsoleKey.NumPad4: //balra numpad (balra menés)
                            if (s != 4)
                            {
                                s = 4;
                            }
                            rossz = false;
                            break;
                        case ConsoleKey.NumPad2: //le numpad (lefelé menés)
                            if (s != 2)
                            {
                                s = 2;
                            }
                            rossz = false;
                            break;
                        case ConsoleKey.NumPad6: //jobbra numpad (jobbra menés)
                            if (s != 6)
                            {
                                s = 6;
                            }
                            rossz = false;
                            break;
                        case ConsoleKey.NumPad7: //keresztbe fel numpad (keresztbe fel menés)
                            if (s != 7)
                            {
                                s = 7;
                            }
                            rossz = false;
                            break;
                        case ConsoleKey.NumPad1: //balra le numpad (balra le menés)
                            if (s != 1)
                            {
                                s = 1;
                            }
                            rossz = false;
                            break;
                        case ConsoleKey.NumPad3: //jobbra le numpad (jobbra le menés)
                            if (s != 3)
                            {
                                s = 3;
                            }
                            rossz = false;
                            break;
                        case ConsoleKey.NumPad9: //jobbra fel numpad(jobbra fel menés)
                            if (s != 9)
                                s = 9;
                            rossz = false;
                            break;
                        case ConsoleKey.NumPad5:
                            rossz = true;
                            break;
                        default:
                            rossz = true;
                            break;

                    }
                    switch (s) // mozgás
                    {
                        case 1:
                            x = x - 1;
                            y = y + 1;
                            break;
                        case 2:
                            y = y + 1;
                            break;
                        case 3:
                            y = y + 1;
                            x = x + 1;
                            break;
                        case 4:
                            x = x - 1;
                            break;
                        case 6:
                            x = x + 1;
                            break;
                        case 7:
                            x = x - 1;
                            y = y - 1;
                            break;
                        case 8:
                            y = y - 1;
                            break;
                        case 9:
                            x = x + 1;
                            y = y - 1;
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                    if (y == 0 || x == 0 || y == also || x == kulso)
                        kilepes = true;
                    
                      
                    }

                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2-10, Console.WindowHeight /2);
                switch(s)
                {
                    case 1:
                        Console.WriteLine("Balra lefele megyek!");
                        break;
                    case 2:
                        Console.WriteLine("Lefele megyek");
                        break;
                    case 3:
                        Console.WriteLine("Jobbra lefele megyek!");
                        break;
                    case 4:
                        Console.WriteLine("Balra megyek!");
                        break;
                    case 6:
                        Console.WriteLine("Jobbra megyek!");
                        break;
                    case 7:
                        Console.WriteLine("Balra fel keresztbe megyek!");
                        break;
                    case 8:
                        Console.WriteLine("Felfele megyek!");
                        break;
                    case 9:
                        Console.WriteLine("Jobbra fel keresztbe megyek! ");
                        break;
                    default:
                        if(rossz == true)
                            Console.WriteLine("Hibás bemeneti gomb!");
                        break;
                }
                if(rossz == true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 -10, Console.WindowHeight / 2 );
                    Console.WriteLine("Hibás bemeneti gomb!");
                }
                Console.SetCursorPosition(x, y);
                //Console.WriteLine(head);
                Thread.Sleep(1000);

            } while (k.Key != ConsoleKey.Escape && kilepes != true);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("vesztettél ! Nyomj egy gombot a kilépéshez");
            Console.ReadKey();


        }
    }
}
