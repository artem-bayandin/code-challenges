using System;

namespace DominoSequenceLibrary
{
    public class Tile : ICloneable
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

        public Tile SetNext(Tile next)
        {
            Next = next;
            return this;
        }

        public override string ToString()
        {
            return Next != null ? $"{Left}-{Right} | {Next}" : $"{Left}-{Right}";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
