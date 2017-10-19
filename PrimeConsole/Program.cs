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
            await PrintPrimesAsync();
            for(int i = 1; i<=10; i++)
            {
                Console.WriteLine(".");
            }
        }
        public static async Task PrintPrimesAsync()
        {
            PrimeService primes = new PrimeService();
            Console.WriteLine("Hello World!");
            Console.WriteLine("Prime numbers less than 100 are:");
            int[] numbers = await Task.Run(()=> primes.GetPrimesInRange(1,1000));
            for(int i = 0; i < numbers.Length; i++)
                Console.Write(numbers[i] + ", ");
        }
    }
}
