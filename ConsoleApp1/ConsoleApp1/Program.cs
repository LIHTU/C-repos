using System;

namespace ConsoleApp1
{
    class Program
    {
        // main - method that's called automatically by the runtime when it launches the application.
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;
            long prevElapsedSeconds = 0;
            while (true)
            {
                DateTime currentTime = DateTime.Now;
                long TotalElapsed = currentTime.Ticks - startTime.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(TotalElapsed);
                float elapsedSeconds = (float)elapsedSpan.TotalSeconds;

                if (elapsedSeconds > prevElapsedSeconds + 1)
                {
                    TotalElapsed = currentTime.Ticks - startTime.Ticks;
                    TimeSpan prevElapsedSpan = new TimeSpan(TotalElapsed);
                    prevElapsedSeconds = (long)elapsedSpan.TotalSeconds;
                    Console.Clear();
                    Console.WriteLine(prevElapsedSeconds);
                }
            }
        }
    }
}
