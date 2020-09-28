using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace kigyo
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = 0; // állapot
            char head = '@';
            Console.CursorVisible = false;
            int x =Console.WindowWidth/ 2;
            int y = Console.WindowHeight / 2;
            Console.Clear();
            Console.SetCursorPosition(x,y);
            Console.Write(head);
            //Console.ReadKey();
            ConsoleKeyInfo k= new ConsoleKeyInfo();
            do
            {
                //if(Console.KeyAvailable)
                    k = Console.ReadKey(true);
                //Console.ReadKey(true);

                switch (k.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (s != 0) s--;

                        break;
                    case ConsoleKey.DownArrow:
                        s = 4;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (s != 0) s--; ;
                        break;
                    case ConsoleKey.RightArrow:
                        x++;
                        break;
                    default:
                        x--;
                        break;
                }
                switch(s)
                {
                        case 0: // fel
                            if (y > 0) y--;
                    break;
                        case 1: //jobbra fel
                            y--; x++;
                    break;
                        case 2: //jobbra
                            x++;
                    break;
                        case 3: //jobbra le
                            x++; y++;
                    break;
                        case 4: // le
                            y++;
                    break;
                        case 5: //balra le
                            y++; x--;
                    break;
                        case 6: //bal
                            x--;
                    break;
                        case 7: //balra fel
                            x--; y--;
                    break;
                }
                //aktuális irány számítás
                Console.Clear();
                try
                {
                    Console.SetCursorPosition(x, y);
                }
                catch (ArgumentOutOfRangeException aute)
                {
                    if (y < 0) y = 0;
                    if (x < 0) x = 0;
                    if (y > 24) y = 24;
                    if (x > 79) x = 79; // ha netán hiba van

                }
                Console.Write(head);
                //Thread.Sleep(1000);
            } while (k.Key != ConsoleKey.Escape);






        }
    }
}
