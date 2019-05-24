using System;

namespace Tutorial
{
    public class MyDelegate
    {
        public delegate void MySayEvent(string str);

        public static void HelloFun(string str)
        {
            Console.WriteLine("  Hello, {0}!", str);
        }
        public static void GoodbyeFun(string str)
        {
            Console.WriteLine("  Goodbye, {0}!", str);
        }

        public void RunDelegate(string str)
        {
            MySayEvent mySayEvent;
            mySayEvent = new MySayEvent(HelloFun);
            mySayEvent += new MySayEvent(GoodbyeFun);
            mySayEvent -= new MySayEvent(HelloFun);

            mySayEvent(str);
        }
    }
}
