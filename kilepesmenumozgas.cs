using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace rendeskigyo
{
    class Program
    {
        public struct adat
            {
            char head;
            int x;
            int y;
            ConsoleColor color;
            }
        static void Main(string[] args)
        {
            bool kilepes = false;
            int s = 1; // állapot
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
            bool felszedte = true;
            int almax = x, almay = y; // alma kezdő helye
            int pontok = 0;
            ConsoleColor r;
            int[,] test = new int[kulso * also, 2]; test[0, 0] = x; test[0, 1] = y;
            do
            {
                if (kilepes == false)
                {
                    if (Console.KeyAvailable)
                    {
                        k = Console.ReadKey(true);
                        switch (k.Key) //gomb megnézése
                        {
                            case ConsoleKey.UpArrow: //felfele gomb
                                switch (s)
                                {
                                    case 2:
                                        s = 1;
                                        break;
                                    case 3:
                                        s = 2;
                                        break;
                                    case 4:
                                        s = 3;
                                        break;
                                    case 6:
                                        s = 7;
                                        break;
                                    case 7:
                                        s = 8;
                                        break;
                                    case 8:
                                        s = 1;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case ConsoleKey.DownArrow: //lefele gomb
                                switch (s)
                                {
                                    case 2:
                                        s = 3;
                                        break;
                                    case 3:
                                        s = 4;
                                        break;
                                    case 4:
                                        s = 5;
                                        break;
                                    case 6:
                                        s = 5;
                                        break;
                                    case 7:
                                        s = 6;
                                        break;
                                    case 8:
                                        s = 7;
                                        break;
                                }
                                break;
                            case ConsoleKey.LeftArrow: //balra gomb
                                switch (s)
                                {
                                    case 1:
                                        s = 8;
                                        break;
                                    case 2:
                                        s = 1;
                                        break;
                                    case 4:
                                        s = 5;
                                        break;
                                    case 5:
                                        s = 6;
                                        break;
                                    case 6:
                                        s = 7;
                                        break;
                                    case 8:
                                        s = 7;
                                        break;
                                }
                                break;
                            case ConsoleKey.RightArrow: //jobbra gomb
                                switch (s)
                                {
                                    case 1:
                                        s = 2;
                                        break;
                                    case 2:
                                        s = 3;
                                        break;
                                    case 4:
                                        s = 3;
                                        break;
                                    case 5:
                                        s = 4;
                                        break;
                                    case 6:
                                        s = 5;
                                        break;
                                    case 8:
                                        s = 1;
                                        break;
                                }
                                break;
                        }
                    }
                    switch (s) // mozgás
                    {
                        case 1:
                            y--;
                            break;
                        case 2:
                            y--; x++;
                            break;
                        case 3:
                            x++;
                            break;
                        case 4:
                            x++; y++;
                            break;
                        case 5:
                            y++;
                            break;
                        case 6:
                            y++; x--;
                            break;
                        case 7:
                            x--;
                            break;
                        case 8:
                            x--; y--;
                            break;
                    }
                    if (y == 0 || x == 0 || y == also - 1 || x == kulso - 1)
                        kilepes = true;
                }
                //alma létrehozása
                Random rnd = new Random();
                if (felszedte == true)
                {
                    almax = rnd.Next(0, kulso + 1);
                    almay = rnd.Next(0, also + 1);
                    felszedte = false;
                }
                //alma lerakása
                Console.Clear();
                if (almax == x && almay == y)
                {
                    felszedte = true;
                    pontok++;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(almax, almay);
                    Console.WriteLine("X");
                }
                //test létrehozása
                int i = pontok;
                if (i != 0)
                {
                    while (i > 0)
                    {
                        test[i, 0] = test[i - 1, 0];
                        test[i, 1] = test[i - 1, 1];
                        if (test[i, 0] == x && test[i, 1] == y)
                            kilepes = true;
                        i--;
                    }
                }
                test[0, 0] = x;
                test[0, 1] = y;
                Console.SetCursorPosition(test[0, 0], test[0, 1]);
                Console.WriteLine(head);
                //test lerakása
                i = pontok;
                if (i != 0 )
                {
                    while (i > 0)
                    {
                        if (i / 2 == 0)
                            r = ConsoleColor.Blue;
                        else
                            r = ConsoleColor.Green;
                        Console.ForegroundColor = r;
                        Console.SetCursorPosition(test[i, 0], test[i, 1]);
                        Console.WriteLine("a");
                        i--;
                    }
                }
                //karakter kiírás része
                /*Console.SetCursorPosition(x, y);
                Console.WriteLine(head);*/
                Thread.Sleep(500);

            } while (k.Key != ConsoleKey.Escape && kilepes != true);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            bool kienged = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("vesztettél !\nPontok száma:{0} \n Nyomd meg a R gombot a  kilépéshez", pontok);
            while(kienged!=true)
            {
                ConsoleKeyInfo gomb = new ConsoleKeyInfo();
                gomb = Console.ReadKey(true);
                if(gomb.Key == ConsoleKey.R)
                {
                    kienged = true;
                }
            }
            //Console.ReadKey();
        }
    }
}
