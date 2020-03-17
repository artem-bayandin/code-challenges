using System;
using FizzBuzzLibrary;

namespace ConsolePlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var divisors = new Divisor[]
            {
                new Divisor(3, "Fizz"),
                new Divisor(5, "Buzz")
            };

            var fizzBuzzArrayed = new FizzBuzzArrayed(
                new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 },
                divisors
            );

            var fizzBuzzRanged1 = new FizzBuzzRanged(15, divisors);

            var fizzBuzzRanged2 = new FizzBuzzRanged(1, 15, divisors);

            ShowFizzBuzz("FizzBuzzArrayed", fizzBuzzArrayed);
            ShowFizzBuzz("FizzBuzzRanged, only last value set", fizzBuzzRanged1);
            ShowFizzBuzz("FizzBuzzRanged, start and end vaules set", fizzBuzzRanged2);

            Console.WriteLine("FIN");
            Console.ReadLine();
        }

        private static void ShowFizzBuzz(string message, FizzBuzz fizzBuzz)
        {
            Console.WriteLine($"Showing: {message}");
            foreach (FizzBuzzResult result in fizzBuzz)
            {
                Console.WriteLine($"{result}");
            }
            Console.WriteLine("Done.");
        }
    }
}
