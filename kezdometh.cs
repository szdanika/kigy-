using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace rendeskigyo
{
    class Tkigyo
    {
        //adat[] Tsnake = new adat[255];
        public void veszetett(int pontok)
        {
            Console.WriteLine("vesztettél !\nPontok száma:{0} \n Nyomd meg a R gombot a  kilépéshez", pontok);
        }
        public void gombnezes(ConsoleKeyInfo k, ref int s)
        {
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
        public void iranyitas(int s, ref int x, ref int y, ref bool kilepes)
        {
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
            if (y == 0 || x == 0 || y == Console.WindowHeight - 2 || x == Console.WindowWidth - 1)
                kilepes = true;
            for (int nezo = 0; nezo < Console.WindowWidth - 1; nezo++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(nezo, Console.WindowHeight-2);
                Console.WriteLine("-");
            }

        }
        public void alma(ref int almax, ref int almay)
        {
                Random rnd = new Random();
                almax = rnd.Next(0, Console.WindowWidth - 1);
                almay = rnd.Next(0, Console.WindowHeight - 2);
                int nezo = 0;
                bool rossz = false;
                /*for (nezo = 0; nezo < aTsnake.Length; nezo++)
                {
                    if (almax == aTsnake[nezo].x)
                    {
                        rossz = true;
                    }
                    if (almay == aTsnake[nezo].y)
                    {
                        rossz = true;
                    }
                }
                if (rossz == true)
                {
                    felszedte = true;
                }
                else
                    felszedte = false;
            }
            //alma lerakása
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
            }*/

        }
    }
    class Program
    {
            public struct adat
            {
            public char head;
            public int x;
            public int y;
            public ConsoleColor color;
            }
        static void Main(string[] args)
        {
            Tkigyo snake = new Tkigyo();
            int[] asd = new int[5];
            adat[] Tsnake = new adat[255];
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
            int[,] test = new int[kulso * also, 2]; test[0, 0] = x; test[0, 1] = y;
            do
            {
                if (kilepes == false)
                {
                    Console.Clear();
                    if (Console.KeyAvailable)
                    {
                        k = Console.ReadKey(true);
                        snake.gombnezes(k, ref s); 
                    }
                    snake.iranyitas(s, ref x, ref y, ref kilepes);
                }
                //alma létrehozása
                Random rnd = new Random();
                while(felszedte == true)
                {
                    almax = rnd.Next(0, kulso -1);
                    almay = rnd.Next(0, also -2);
                    int nezo = 0;
                    bool rossz = false;
                    for (nezo = 0; nezo < Tsnake.Length; nezo++)
                    {
                        if(almax ==Tsnake[nezo].x)
                        {
                            rossz = true;
                        }
                        if(almay == Tsnake[nezo].y)
                        {
                            rossz = true;
                        }
                    }
                    if(rossz == true)
                    {
                        felszedte = true;
                    }
                    else
                        felszedte = false;
                }
                //alma lerakása
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
                        Tsnake[i].x = Tsnake[i - 1].x;
                        Tsnake[i].y = Tsnake[i - 1].y;
                        Tsnake[i].color = Tsnake[i - 1].color;
                        if (Tsnake[i].color == ConsoleColor.White || Tsnake[i].color == ConsoleColor.Blue)
                            Tsnake[i].color = ConsoleColor.Red;
                        else
                            if (Tsnake[i].color == ConsoleColor.Red)
                                Tsnake[i].color = ConsoleColor.Blue;





                        //test[i, 0] = test[i - 1, 0];
                        //test[i, 1] = test[i - 1, 1];
                        if (test[i, 0] == x && test[i, 1] == y)
                            kilepes = true;
                        i--;
                    }
                }
                Tsnake[0].x = x;
                Tsnake[0].y = y;
                Tsnake[0].color = ConsoleColor.White;
                //test[0, 0] = x;
                //test[0, 1] = y;
                //Console.SetCursorPosition(test[0, 0], test[0, 1]);
                Console.SetCursorPosition(Tsnake[0].x, Tsnake[0].y);
                Console.WriteLine(head);
                //test lerakása
                i = pontok;
                if (i != 0 )
                {
                    while (i > 0)
                    {
                        Console.ForegroundColor = Tsnake[i].color;
                        Console.SetCursorPosition(Tsnake[i].x, Tsnake[i].y);
                        Console.WriteLine("a");
                        i--;
                    }
                }
                //karakter kiírás része
                /*Console.SetCursorPosition(x, y);
                Console.WriteLine(head);*/
                Thread.Sleep(500);
                bool bennevane = false;
                if (pontok > 0)
                {
                    while (bennevane == false)
                    {
                        int nezo = 1;
                        for (nezo = 1; nezo < Tsnake.Length; nezo++)
                        {
                            if (Tsnake[nezo].x == Tsnake[0].x && Tsnake[nezo].y == Tsnake[0].y)
                            {
                                bennevane = true;
                                kilepes = true;
                            }
                        }
                        bennevane = true;
                    }
                }
            } while (k.Key != ConsoleKey.Escape && kilepes != true);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            bool kienged = false;
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("vesztettél !\nPontok száma:{0} \n Nyomd meg a R gombot a  kilépéshez", pontok);
            snake.veszetett(pontok);
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
