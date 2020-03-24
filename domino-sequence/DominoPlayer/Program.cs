using DominoSequenceLibrary;
using System;

namespace DominoPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var domino = new Domino();

            Console.WriteLine(domino.GetMaxDepth("6-3"));
            Console.WriteLine(domino.GetMaxDepth("1-2,1-2"));
            Console.WriteLine(domino.GetMaxDepth("1-1,3-5,5-2,2-3,2-4"));

            Console.ReadLine();
        }
    }
}
