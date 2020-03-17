using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeLibrary.Tests.Constants
{
    public static class TestConstants
    {
        public static IEnumerable<object[]> ObjectDelimiters => Delimiters.Select(del => new object[] { del });
        public static string[] Delimiters => new string[] { " ", "0", "1", "2", "a", "b", "!", "#", "_" };
        public static int[] NumbersOfNodes
        {
            get
            {
                var rnd = new Random();
                return new int[] { 0, rnd.Next(10, 49), rnd.Next(50, 199), rnd.Next(200, 1000) };
            }
        }
    }
}
