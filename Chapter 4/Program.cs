using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_4
{
    class Program
    {
        static ConsoleKeyInfo keyInfo;
        static void Main(string[] args)
        {
            Thread st1 = new Thread(PrintPrimes);

            st1.Start();

            do
            {
                keyInfo = Console.ReadKey();
                if(keyInfo.Key == ConsoleKey.P)
                {
                    st1.Suspend();
                }
                else if(keyInfo.Key == ConsoleKey.R)
                {
                    st1.Resume();
                }
            }
            while (keyInfo.Key != ConsoleKey.Escape);

            st1.Abort();

        }

        static void PrintPrimes()
        {
            int n = 10000;
            bool[] A = new bool[n];

            for (int i = 2; i < n; i++)
            {
                A[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(n) + 1; ++i)
            {
                if (A[i])
                {
                    for (int j = i * i; j < n; j += i)
                    {
                        A[j] = false;
                    }
                }
            }
         
            for (int i = 2; i < n; i++)
            {
                if (A[i])
                {
                    Console.WriteLine("{0} ", i);
                    Thread.Sleep(500);
                }
            } 
            
        }
    }
}
