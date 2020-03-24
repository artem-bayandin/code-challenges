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

            var maxDepth = 0;

            foreach (var item in tiles)
            {
                var depth = GetDepth(1, item, tiles);

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                }
            }

            return maxDepth;
        }

        private int GetDepth(int currentDepth, Tile tile, List<Tile> allTiles)
        {
            var otherTiles = allTiles.Where(x => x.Id != tile.Id).ToList();

            var tilesToConnect = otherTiles.Where(t => t.Left == tile.Right).ToList();

            foreach (var item in tilesToConnect)
            {
                var depth = GetDepth(currentDepth + 1, item, otherTiles);

                if (depth > currentDepth)
                {
                    currentDepth = depth;
                }
            }

            return currentDepth;
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
