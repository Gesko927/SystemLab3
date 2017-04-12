using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Chapter_2_Spin_Lock
{
    class Program
    {
        static bool o;
        static bool isEnd = false;
        static SpinLock locking = new SpinLock();
        static void Main(string[] args)
        {

            Thread st1 = new Thread(Print);
            Thread st2 = new Thread(Print);

            o = false;

            st1.Start();
            st2.Start();


        }

        static void Print()
        {
            locking.Enter(ref o);
            if (!isEnd)
            {
                for (int i = 0; i <= 500; i += 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(i + " ");
                }
                isEnd = true;
                locking.Exit();
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
