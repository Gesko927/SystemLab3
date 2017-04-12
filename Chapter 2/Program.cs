using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_2
{
    class Program
    {
        static object o = new object();

        static bool isEnd = false;
        static void Main(string[] args)
        {

            Thread st1 = new Thread(printOdd);
            Thread st2 = new Thread(printOdd);

            st1.Start();
            st2.Start();
        }

        static void printOdd()
        {
            lock(o)
            {
                if (!isEnd)
                {
                    for (int i = 0; i <= 500; i += 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(i + " ");
                    }

                    isEnd = true;
                }
                else
                {
                    for (int i = 1; i < 500; i += 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
