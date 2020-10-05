using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace danikigyo
{
    class Program
    {
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
            int almax = x, almay = y;
            int pontok = 1;
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
                            x++;y++;
                            break;
                        case 5:
                            y++;
                            break;
                        case 6:
                            y++;x--;
                            break;
                        case 7:
                            x--;
                            break;
                        case 8:
                            x--;y--;
                            break;
                    }
                    if (y == 0 || x == 0 || y == also-1 || x == kulso-1)
                        kilepes = true;
                }
                //alma létrehozása
                Random rnd = new Random();
                if(felszedte == true)
                {
                    almax = rnd.Next(0, kulso+1);
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
                    Console.SetCursorPosition(almax, almay);
                    Console.WriteLine("X");
                }
                //test létrehozása

                /*for(int i = pontok ; i > 0; i++)
                {
                    test[i, 0] = test[i - 1, 0];
                    test[i, 1] = test[i - 1, 1];
                    if(i == 1)
                    {
                        test[0, 0] = x;
                        test[0, 1] = y;
                    }







                    /*if(i == 0)
                    {
                        Console.SetCursorPosition(test[i,0], test[i,1]);
                        Console.WriteLine(head);
                    }
                    else
                    {
                        Console.SetCursorPosition(test[i, 0], test[i, 1]);
                        Console.WriteLine("a");
                    }
                }
                Console.SetCursorPosition(test[0, 0], test[0, 1]);
                Console.WriteLine(head);
                for(int i = 1; i < pontok+1; i++)
                {
                    Console.SetCursorPosition(test[i, 0], test[i, 1]);
                    Console.WriteLine("a");
                }*/





                //karakter kiírás része
                Console.SetCursorPosition(x, y);
                Console.WriteLine(head);
                Thread.Sleep(500);

            } while (k.Key != ConsoleKey.Escape && kilepes != true);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("vesztettél !Pontok száma:{0} Nyomj egy gombot a kilépéshez", pontok-1);
            Console.ReadKey();

        }
    }
}
