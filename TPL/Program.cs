using System;
using System.Threading.Tasks;

namespace TPL
{
    internal class Program
    {
        private static readonly Task[] tasks = new Task[7];

        private static void Show_Thread1(object obj)
        {
            Console.WriteLine(obj);
        }

        private static void Show_Thread2(object obj)
        {
            Task.WaitAny(tasks[0]);
            Console.WriteLine(obj);
        }

        private static void Show_Thread3(object obj)
        {
            Task.WaitAny(tasks[0]);
            Console.WriteLine(obj);
        }

        private static void Show_Thread4(object obj)
        {
            Task.WaitAny(tasks[2]);
            Console.WriteLine(obj);
        }

        private static void Show_Thread5(object obj)
        {
            Task.WaitAny(tasks[1]);
            Console.WriteLine(obj);
        }

        private static void Show_Thread6(object obj)
        {
            Task.WaitAny(tasks[1]);
            Console.WriteLine(obj);
        }

        private static void Show_Thread7(object obj)
        {
            Task.WaitAny(tasks[2]);
            Console.WriteLine(obj);
        }

        private static void Main(string[] args)
        {
            tasks[0] = Task.Factory.StartNew(() => Show_Thread1("Thread 1"));
            tasks[1] = Task.Factory.StartNew(() => Show_Thread2("Thread 2"));
            tasks[2] = Task.Factory.StartNew(() => Show_Thread3("Thread 3"));
            tasks[3] = Task.Factory.StartNew(() => Show_Thread4("Thread 4"));
            tasks[4] = Task.Factory.StartNew(() => Show_Thread5("Thread 5"));
            tasks[5] = Task.Factory.StartNew(() => Show_Thread6("Thread 6"));
            tasks[6] = Task.Factory.StartNew(() => Show_Thread7("Thread 7"));


            Console.ReadKey();
        }
    }
}