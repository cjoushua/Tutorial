using NUnit.Framework;
using System;
using System.Threading;

namespace MyMultiThread
{
    class MyMultiThread
    {
        [Test]
        public void DoMyMultiThread()
        {
            Thread Trd1 = new Thread(new ThreadStart(Doprint.DoPrintOne));
            Thread Trd2 = new Thread(new ThreadStart(Doprint.DoPrintTwo));

            Trd1.Start();
            Trd2.Start();
            Console.ReadLine();
        }
    }


    public class Doprint
    {
        public static void DoPrintOne()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Print One {0}", i);
            }
        }

        public static void DoPrintTwo()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Print Two {0}", i);
            }
        }
    }
}
