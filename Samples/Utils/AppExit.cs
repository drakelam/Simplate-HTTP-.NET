﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo
{
    static class AppExit
    {
        public static void WaitFor(CancellationTokenSource cts, params Task[] tasks)
        {
            if (cts == null)
                throw new ArgumentNullException(nameof(cts));

            if (tasks == null)
                throw new ArgumentNullException(nameof(tasks));

            Task.Run(() =>
            {
                Console.WriteLine("------Press [Enter] to stop------");
                Console.ReadLine();

                cancelTasks(cts);
            });

            waitTasks(tasks);
        }

        static void cancelTasks(CancellationTokenSource cts)
        {
            Console.WriteLine("\nWaiting for the tasks to complete...");
            cts.Cancel();
        }

        static void waitTasks(Task[] tasks)
        {
            try
            {
                foreach (var t in tasks) //enables exception handling
                    t.Wait();
            }
            catch (Exception ex)
            {
                writeError(ex);
            }
        }

        static void writeError(Exception ex)
        {
            if (ex == null)
                return;

            if (ex is AggregateException)
                ex = ex.InnerException;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + ex.Message);
            Console.ResetColor();
        }
    }
}
