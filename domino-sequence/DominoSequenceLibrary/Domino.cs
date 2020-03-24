using System;
using System.Collections.Generic;
using System.Linq;

namespace DominoSequenceLibrary
{
    public class Domino
    {
        #region Sequence

        public List<Tile> GetSequences(string input)
        {
            var tiles = Deserialize(input);

            var result = new List<Tile>();

            foreach (var tile in tiles)
            {
                var sequence = GetNextSequence(tile, tiles);
                if (sequence.Any())
                {
                    foreach (var item in sequence)
                    {
                        var clone = (Tile)tile.Clone();
                        clone.SetNext(item);
                        result.Add(clone);
                    }
                }
                else
                {
                    result.Add(tile);
                }
            }

            return result;
        }

        private List<Tile> GetNextSequence(Tile tile__, List<Tile> tiles)
        {
            var other__ = tiles.Where(x => x.Id != tile__.Id).ToList();

            var next = other__.Where(x => x.Left == tile__.Right).ToList();

            var result = new List<Tile>();

            foreach (var tile in next)
            {
                var sequence = GetNextSequence(tile, other__);
                if (sequence.Any())
                {
                    foreach (var item in sequence)
                    {
                        var clone = (Tile)tile.Clone();
                        clone.SetNext(item);
                        result.Add(clone);
                    }
                }
                else
                {
                    result.Add(tile);
                }
            }

            return result;
        }

        #endregion

        #region Depth

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

        #endregion

        private List<Tile> Deserialize(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return new List<Tile>();
            }

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
