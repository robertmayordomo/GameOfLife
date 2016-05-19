using System.Collections.Generic;
using System.Linq;
using GameOfLife.GameModels;

namespace GameOfLife.Utilities
{
    internal static class GridBuilder
    {
        public static IEnumerable<Cell> GenerateGrid(int size)
        {
            return from x in Enumerable.Range(0, size)
                from y in Enumerable.Range(0, size)
                select Cell.CreateDead(x, y);
        }
    }
}