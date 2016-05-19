using System;
using System.Diagnostics;

namespace GameOfLife.GameModels
{
    [DebuggerDisplay("x={X},y={Y}")]
    public class Cell : IEquatable<Cell>
    {
        public int X { get; }
        public int Y { get; }
        public bool IsAlive { get; }
        public static Cell CreateLive(int x, int y) { return new Cell(x, y); }
        public static Cell CreateDead(int x, int y) { return new Cell(x, y, false); }

        private Cell(int x, int y, bool isAlive = true)
        {
            X = x;
            Y = y;
            IsAlive = isAlive;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public bool Equals(Cell other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Cell && Equals((Cell)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}