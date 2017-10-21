using System;
using System.Threading;
using System.Threading.Tasks;
using PrimeNumbers;

namespace PrimeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain(args).Wait();
            Console.WriteLine("Program end.");
            Console.ReadLine();
        }

        public static async Task AsyncMain(string[] args)
        {
            PrimeService primes = new PrimeService();
            Task<int[]> primeGenerator = primes.GetPrimesInRangeAsync(1000, 1000000);
            Console.Write("Elapsed Time ... ");
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            while( !primeGenerator.IsCompleted)
            {
                Console.CursorLeft = 31;
                Console.Write(stopwatch.ElapsedMilliseconds);
            }
            Console.WriteLine();
            int[] primeNumbers = await primeGenerator;
            for (int i = 0; i < primeNumbers.Length; i++)
                Console.Write("p[{0}]={1}. ", i, primeNumbers[i]);
            Console.WriteLine();
        }
        public static async Task PrintPrimesAsync()
        {
            PrimeService primes = new PrimeService();
            Console.WriteLine("Hello World!");
            Console.WriteLine("Prime numbers less than 100 are:");
            await Task.Delay(100000);
            int[] numbers = await Task.Run(()=> primes.GetPrimesInRange(100000,200000));
            for(int i = 0; i < numbers.Length; i++)
                Console.Write(numbers[i] + ", ");
        }
    }
}
