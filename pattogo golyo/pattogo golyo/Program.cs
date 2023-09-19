using System;
using System.Threading;


namespace pattogo_golyo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Clear();


            int w = Console.WindowWidth;
            int h = Console.WindowHeight;

            #region keret

            Console.WriteLine("╔");

            Console.SetCursorPosition(w - 1, 0);
            Console.WriteLine("╗");

            Console.SetCursorPosition(0, h - 1);
            Console.WriteLine("╚");

            Console.SetCursorPosition(w - 1, h - 1);
            Console.WriteLine("╝");


            // alsó és felső keret

            for (int x = 1; x <= w - 2; x++) 
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("═");

                Console.SetCursorPosition(x, h - 1);
                Console.Write("═");
            }

            // oldalsó keret

            for (int y=1; y <= h-2; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("║");

                Console.SetCursorPosition(w-1, y);
                Console.Write("║");
            }

            #endregion

            Random r = new Random();
            int x_hely = r.Next(1, w - 1);
            int y_hely = r.Next(1, h-1);

            bool x_irany = true;
            bool y_irany = true;
            int speed = 10;
            while (speed<100)
            {
                Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x_hely, y_hely);
             Console.Write("O");

                // irányváltás
                if (x_hely == 1 || x_hely == w - 2)
                {
                    x_irany = !x_irany;
                    speed += 10;
                }
                if (y_hely == 1 || y_hely == h - 2)
                {
                    y_irany = !y_irany;
                    speed += 10;
                }

                Thread.Sleep(speed);

                // golyó útvonal törlés
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x_hely, y_hely);
                Console.Write("█");

                // mozgás
                if (x_irany && y_irany)
                {
                    x_hely++;
                    y_hely++;
                }

                if (x_irany && !y_irany)
                {
                    x_hely++;
                    y_hely--;
                }

                if (!x_irany && y_irany)
                {
                    x_hely--;
                    y_hely++;
                }

                if (!x_irany && !y_irany)
                {
                    x_hely--;
                    y_hely--;
                }
                
                
            }

            

            Console.ReadKey();

        }
    }
}
