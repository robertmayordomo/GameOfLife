using System.Collections.Generic;
using System.Linq;
using GameOfLife.GameModels;

namespace GameOfLife.Utilities
{
    internal static class GridBuilder
    {
        /// <summary>
        /// Supplies a gird with half the coordinates on the negative side of the x nd y axis 
        /// </summary>
        /// <param name="size">the amount of cells in the positive and negative axis of the grid</param>
        /// <returns>All Cells, for a size 5 would return 121 cells, 5 positive 5 negative and the cell rows/column on the 0 index.</returns>
        public static IEnumerable<Cell> GenerateGrid(int size)
        {
            for (var x = -size; x <= size; x++)
            {
                for (var y = -size; y <= size; y++)
                {
                    yield return Cell.CreateDead(x, y);
                }
            }
        }
    }
}