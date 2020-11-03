using System;
using System.Threading;

namespace snaketype
{
    public struct SSnake
    {
        public int x;
        public int y;
        public char c;
        public ConsoleColor color;
    }
    class TSnake
    {
        SSnake[] sn = new SSnake[300];
        public void snRead()
        {
           
        }
        public void snWrite(int _x)
        {
            sn[_x].x = _x;
        }
        public void snChange()
        {

        }
        public void snChange(int s)
        {

        }
    }
    class TFruit: TSnake
    {
        int pontSzam;
        public void pontSzamMod(int x)
        {
            pontSzam = x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo k = new ConsoleKeyInfo();
            TSnake snake = new TSnake();
            TSnake rSnake = new TSnake();
            TFruit fruit = new TFruit();
            do
            {
                // bill beolvasás, állapot beéllítás
                snake.snChange(10);
                snake.snRead();
                snake.snWrite(10);
                fruit.snRead();
                fruit.pontSzamMod(20);
            } while (true);
            Console.WriteLine();
        }
    }
}
