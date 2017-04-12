using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_5
{
    class Program
    {
        #region ManualResetEvent
        class MyThread
        {
            public Thread Thrd;

            ManualResetEvent mre;

            public MyThread(string name, ManualResetEvent evt)
            {
                Thrd = new Thread(this.Run);
                Thrd.Name = name;
                mre = evt;
                Thrd.Start();
            }

            void Run()
            {
                Console.WriteLine("In " + Thrd.Name);

                for (int i = 0; i < 5; i++)
                {

                    Console.WriteLine(i.ToString());
                    Thread.Sleep(500);
                }

                Console.WriteLine(Thrd.Name + " finish!");

                mre.Set();
            }
        }

        static void Main()
        {
            ManualResetEvent evtObj = new ManualResetEvent(false);

            MyThread mt1 = new MyThread("Thread #1", evtObj);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Main thread waiting for event");

            evtObj.WaitOne();

            Console.WriteLine("Main thread got signal from FIRST thread");

            evtObj.Reset();

            Console.ForegroundColor = ConsoleColor.Red;
            mt1 = new MyThread("Thread #2", evtObj);

            Console.WriteLine("Main thread waiting for event");
            evtObj.WaitOne();

            Console.WriteLine("Основной поток получил уведомление о событии от второго потока");
        }
        #endregion

        #region AutoResetEvent

        //class MyThread
        //{
        //    public Thread Thrd;

        //    AutoResetEvent are;


        //    public MyThread(string name, AutoResetEvent evt)
        //    {
        //        Thrd = new Thread(this.Run);
        //        Thrd.Name = name;
        //        are = evt;
        //        Thrd.Start();
        //    }

        //    void Run()
        //    {
        //        Console.WriteLine("In " + Thrd.Name);

        //        for (int i = 0; i < 5; i++)
        //        {
        //            Console.WriteLine(i.ToString());
        //            Thread.Sleep(500);
        //        }

        //        Console.WriteLine(Thrd.Name + " finish!");


        //        are.Set();
        //    }
        //}

        //static void Main()
        //{
        //    AutoResetEvent evtObj = new AutoResetEvent(false);

        //    MyThread mt1 = new MyThread("Thread #1", evtObj);

        //    Console.ForegroundColor = ConsoleColor.Green;

        //    Console.WriteLine("Main thread waiting for event");
        //    evtObj.WaitOne();

        //    Console.WriteLine("Main thread got signal from FIRST thread");

        //    Console.ForegroundColor = ConsoleColor.Red;

        //    mt1 = new MyThread("Thread #2", evtObj);

        //    Console.WriteLine("Main thread waiting for event");

        //    evtObj.WaitOne();

        //    Console.WriteLine("Main thread got signal from SECOND thread");
        //}

        #endregion
    }
}

