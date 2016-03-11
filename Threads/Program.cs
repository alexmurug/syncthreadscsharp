using System;
using System.Threading;

internal class Program
{
    private static readonly CountdownEvent cde1 = new CountdownEvent(1);
    private static readonly CountdownEvent cde2 = new CountdownEvent(1);
    private static readonly CountdownEvent cde3 = new CountdownEvent(1);


    private static void Show_Thread1(object obj)
    {
        Console.WriteLine(obj);
        cde1.Signal();
    }

    private static void Show_Thread2(object obj)
    {
        cde1.Wait();
        Console.WriteLine(obj);
        cde2.Signal();
    }

    private static void Show_Thread3(object obj)
    {
        cde1.Wait();
        Console.WriteLine(obj);
        cde3.Signal();
    }

    private static void Show_Thread4(object obj)
    {
        cde3.Wait();
        Console.WriteLine(obj);
    }

    private static void Show_Thread5(object obj)
    {
        cde2.Wait();
        Console.WriteLine(obj);
    }

    private static void Show_Thread6(object obj)
    {
        cde2.Wait();
        Console.WriteLine(obj);
    }

    private static void Show_Thread7(object obj)
    {
        cde3.Wait();
        Console.WriteLine(obj);
    }

    private static void Main()
    {
        new Thread(Show_Thread1).Start("Thread 1");

        var t2 = new Thread(Show_Thread2);
        t2.Start("Thread 2");
        var t3 = new Thread(Show_Thread3);
        t3.Start("Thread 3");
        new Thread(Show_Thread4).Start("Thread 4");
        new Thread(Show_Thread5).Start("Thread 5");
        new Thread(Show_Thread6).Start("Thread 6");
        new Thread(Show_Thread7).Start("Thread 7");


        Console.ReadKey();
    }
}