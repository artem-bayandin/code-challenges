using System;
using System.Collections.Generic;

namespace CrossCutting
{
    public class DataGenerator
    {
        private static Random _random = new Random();
        public const int MaxRandomItemsCount = 10000;

        public static IEnumerable<int> FullTreeData()
        {
            foreach (var item in new int[] { 16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30, 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31 })
            {
                yield return item;
            }
        }

        public static IEnumerable<int> RandomTreeData(int numberOfItems)
        {
            var result = new List<int>();

            if (numberOfItems > MaxRandomItemsCount)
            {
                numberOfItems = MaxRandomItemsCount;
            }

            var upper = numberOfItems * 3;

            while (result.Count < numberOfItems)
            {
                var item = _random.Next(0, upper);
                if (result.Contains(item))
                {
                    continue;
                }
                result.Add(item);
            }

            return result;
        }
    }
}
