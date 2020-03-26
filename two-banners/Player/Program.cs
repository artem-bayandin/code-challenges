using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Player
{
    public class TestItem
    {
        public int Expected { get; }
        public int[] Input { get; }

        public TestItem(int[] input, int result)
        {
            Input = input;
            Expected = result;
        }
    }
    public static class TestData
    {
        private static List<TestItem> _collection;
        public static List<TestItem> Collection
        {
            get
            {
                if (_collection == null)
                {
                    var rnd = new Random();
                    var arr7500 = CreateArray(7500, rnd);
                    var arr100k = CreateArray(100000, rnd);
                    _collection = new List<TestItem>
                    {
                        //new TestItem(new int[] { 3, 1, 4 }, 10)
                        //, new TestItem(new int[] { 5, 3, 2, 4 }, 17)
                        //, new TestItem(new int[] { 5, 3, 5, 2, 1 }, 19)
                        //, new TestItem(new int[] { 7, 7, 3, 7, 7 }, 35)
                        //, new TestItem(new int[] { 1, 1, 7, 6, 6, 6 }, 30)
                        //, 
                        new TestItem(arr7500, -1)
                        , new TestItem(arr100k, -1)
                    };
                }
                return _collection;
            }
        }

        private static int[] CreateArray(int number, Random rnd)
        {
            var arr = new int[number];
            for (var i = 0; i < number; i++)
            {
                arr[i] = rnd.Next(1, 10000);
            }
            return arr;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in TestData.Collection)
            {
                Console.WriteLine($"Calculating {item.Input.Length}...");
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                var actual = Calculate(item.Input);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                //Console.WriteLine($"{item.Expected == actual} -> expected: {item.Expected}, actual: {actual}");
                Console.WriteLine($"Done in {ts.TotalMilliseconds}ms. Actual: {actual}");
            }

            Console.WriteLine("FIN");
            Console.ReadLine();
        }

        static int Calculate(int[] H)
        {
            var span = new List<int>(H);

            // recursive method should have started here

            var count = span.Count;
            if (count == 1) return span[0];
            if (count == 2) return span[0] + span[1];

            var max = span.Max();

            var banner = count * max;

            var left = 0;

            var leftMax = 0;
            var leftCount = 0;

            for (var i = 0; i < span.Count; i++)
            {
                leftCount++;
                leftMax = Math.Max(leftMax, span[i]);
                left = leftCount * leftMax;

                var newArr = span.Skip(1 + i);
                max = newArr.Any() ? newArr.Max() : 0;

                var right = (count - i - 1) * max;
                var newBanner = left + right;

                if (newBanner < banner)
                {
                    banner = newBanner;
                }
            }

            return banner;
        }
    }
}
