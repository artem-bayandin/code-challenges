using System;
using System.Collections.Generic;
using System.Linq;

namespace DominoSequenceLibrary
{
    public class Tile
    {
        public Guid Id { get; private set; }
        public int Left { get; private set; }
        public int Right { get; private set; }

        public Tile Next { get; internal set; }

        public Tile(int left, int right) : this(Guid.NewGuid(), left, right) { }

        public Tile(Guid id, int left, int right)
        {
            Id = id;
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return $"{Left}-{Right}";
        }
    }

    public class Domino
    {
        //public IEnumerable<Tile> CalculateSequence(string input)
        //{
        //    var tiles = Deserialize(input);

        //    foreach (var item in tiles)
        //    {
        //        var others = tiles
        //            .Where(t => t.Id != item.Id)
        //            .ToList();

        //        yield return item;

        //        foreach (var tile in CalculateSequence(item, others))
        //        {
        //            yield return tile;
        //        }
        //    }
        //}

        public int GetMaxDepth(string input)
        {
            var tiles = Deserialize(input);

            var maxRoute = 0;

            foreach (var item in tiles)
            {
                var others = tiles
                    .Where(t => t.Id != item.Id)
                    .ToList();

                var route = GetDepth(1, item, others);

                if (route > maxRoute)
                {
                    maxRoute = route;
                }
            }

            return maxRoute;
        }

        private int GetDepth(int depth, Tile tile, List<Tile> tiles)
        {
            if (!tiles.Any())
            {
                return depth;
            }

            var maxRoute = depth;

            var tilesToConnect = tiles.Where(t => t.Left == tile.Right).ToList();

            foreach (var item in tilesToConnect)
            {
                var others = tiles
                    .Where(t => t.Id != item.Id)
                    .ToList();

                var route = GetDepth(depth + 1, item, others);

                if (route > maxRoute)
                {
                    maxRoute = route;
                }
            }

            return maxRoute;
        }

        private List<Tile> Deserialize(string input)
        {
            return input
                .Split(',')
                .Select(x =>
                {
                    var values = x.Split('-').Select(Int32.Parse).ToArray();
                    return new Tile(values[0], values[1]);
                })
                .ToList();
        }
    }
}
