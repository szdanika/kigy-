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
        public struct adat
        {
            public int x;
            public int y;
            public ConsoleColor color;
        }
        adat[] Tsnake = new adat[255];
        //adatok deklarálás
        private bool kilepes = false;
        private int s = 1;
        private char head = '@';
        private int x = Console.WindowWidth / 2;
        private int y = Console.WindowHeight / 2;
        private int kulso = Console.WindowWidth;
        private int also = Console.WindowHeight;
        private int almax = 0, almay = 0;
        private int pontok = 0;
        ConsoleKeyInfo k = new ConsoleKeyInfo();
        //
        /*Tkigyo()
        {

        }*/
        public void menu()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Üdvözölek a menüben");
            Console.WriteLine("Játék kezdéséhez nyomj egy 'r' betüt, kilépéshez pedig egy 'q' betüt!");
            bool kienged = false;
            while (kienged != true)
            {
                ConsoleKeyInfo gomb = new ConsoleKeyInfo();
                gomb = Console.ReadKey(true);
                if (gomb.Key == ConsoleKey.R)
                {
                    kezdo();
                    kienged = true;
                }
                if(gomb.Key == ConsoleKey.Q)
                {
                    kienged = true;
                }
            }
        }
        public void szam()
        {
            Random rando = new Random();
            almax = rando.Next(0, Console.WindowWidth - 1);
            almay = rando.Next(0, Console.WindowHeight - 1);
        }
        public void kezdo()
        {
            szam();
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write(head);
            int[,] test = new int[kulso * also, 2]; test[0, 0] = x; test[0, 1] = y;
            jatekresze();
        }
        public void jatekresze()
        {
            do
            {
                if (kilepes == false)
                {
                    Console.Clear();
                    if (Console.KeyAvailable)
                    {
                        k = Console.ReadKey(true);
                        gombnezes();
                    }
                    iranyitas();
                }
            } while (k.Key != ConsoleKey.Escape && kilepes != true);
            veszetett();
        }
        public void veszetett()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            bool kienged = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("vesztettél !\nPontok száma:{0} \n Nyomd meg a 'R' gombot a  menühöz lépéshez! Kilépéshez pedig a 'q' gombot", pontok);
            while (kienged != true)
            {
                ConsoleKeyInfo gomb = new ConsoleKeyInfo();
                gomb = Console.ReadKey(true);
                if (gomb.Key == ConsoleKey.R)
                {
                    kienged = true;
                    menu();
                }
                if(gomb.Key == ConsoleKey.Q)
                {
                    kienged = true;
                }
            }
        }
        public void gombnezes()
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
        public void iranyitas()
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
                Console.SetCursorPosition(nezo, Console.WindowHeight - 2);
                Console.WriteLine("-");
            }
            if (almax == x && almay == y)
                alma();
            else
                almalerakas();
            test();
        }
        public void alma()
        {
            pontok++;
            Random rnd = new Random();
            almax = rnd.Next(0, Console.WindowWidth - 1);
            almay = rnd.Next(0, Console.WindowHeight - 2);
            int nezo = 0;
            bool rossz = true;
            while (rossz == true)
            {
                almax = rnd.Next(0, Console.WindowWidth - 1);
                almay = rnd.Next(0, Console.WindowHeight - 2);
                int rosszdb = 0;
                for (nezo = 0; nezo < Tsnake.Length; nezo++)
                {
                    if (almax == Tsnake[nezo].x || almay == Tsnake[nezo].y)
                    {
                        rosszdb++;
                    }
                }
                if (!(rosszdb > 0))
                {
                    rossz = false;
                }
            }
            almalerakas();
        }
        public void almalerakas()
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(almax, almay);
            Console.WriteLine("X");
        }
        public void test()
            {
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
                    i--;

                }
            }
            Tsnake[0].x = x;
            Tsnake[0].y = y;
            Tsnake[0].color = ConsoleColor.White;
            Console.SetCursorPosition(Tsnake[0].x, Tsnake[0].y);
            Console.WriteLine(head);
            //test lerakása
            i = pontok;
            if (i != 0)
            {
                while (i > 0)
                {
                    Console.ForegroundColor = Tsnake[i].color;
                    Console.SetCursorPosition(Tsnake[i].x, Tsnake[i].y);
                    Console.WriteLine("a");
                    i--;
                }
            }
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
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tkigyo snake = new Tkigyo();
            //snake.kezdo();
            snake.menu();
        }
    }
}
