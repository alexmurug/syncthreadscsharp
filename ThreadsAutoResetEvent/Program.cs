using System;
using System.Threading;

internal class Program
{
    private static readonly AutoResetEvent are1 = new AutoResetEvent(false);
    private static readonly AutoResetEvent are2 = new AutoResetEvent(false);
    private static readonly AutoResetEvent are3 = new AutoResetEvent(false);



    private static void Show_Thread1(object obj)
    {
        Console.WriteLine(obj);
        are1.Set();
    }

    private static void Show_Thread2(object obj)
    {
        are1.WaitOne();
        Console.WriteLine(obj);
        are2.Set();
    }

    private static void Show_Thread3(object obj)
    {
        are1.WaitOne();
        Console.WriteLine(obj);
        are3.Set();
    }

    private static void Show_Thread4(object obj)
    {
        are3.WaitOne();
        Console.WriteLine(obj);
    }

    private static void Show_Thread5(object obj)
    {
        are2.WaitOne();
        Console.WriteLine(obj);
    }

    private static void Show_Thread6(object obj)
    {
        are2.WaitOne();
        Console.WriteLine(obj);
    }

    private static void Show_Thread7(object obj)
    {
        are3.WaitOne();
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