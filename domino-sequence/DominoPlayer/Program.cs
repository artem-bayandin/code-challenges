using DominoSequenceLibrary;
using System;
using System.Collections.Generic;

namespace DominoPlayer
{
    class Program
    {
        static List<string> Data = new List<string>
        {
            "",
            "6-3",
            "1-2,1-2",
            "1-1,3-5,5-2,2-3,2-4"
        };

        static void Main(string[] args)
        {
            var domino = new Domino();

            foreach (var data in Data)
            {
                Console.WriteLine($"'{data}' => {domino.GetMaxDepth(data)}");

                var sequence = domino.GetSequences(data);
                foreach (var tile in sequence)
                {
                    Console.WriteLine(tile);
                }
            }

            Console.ReadLine();
        }
    }
}
