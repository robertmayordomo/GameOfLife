using System.Collections.Generic;
using System.Linq;
using GameOfLife.GameModels;

namespace GameOfLife.Utilities
{
    public static class CellHelper
    {
        private static IEnumerable<Cell> GetSurroundingCells(Cell cell)
        {
            var x = cell.X;
            var y = cell.Y;

            yield return Cell.CreateLive(x - 1, y - 1);
            yield return Cell.CreateLive(x - 1, y);
            yield return Cell.CreateLive(x - 1, y + 1);
            yield return Cell.CreateLive(x, y - 1);
            yield return Cell.CreateLive(x, y + 1);
            yield return Cell.CreateLive(x + 1, y - 1);
            yield return Cell.CreateLive(x + 1, y);
            yield return Cell.CreateLive(x + 1, y + 1);
        }

        public static IEnumerable<Cell> GetLiveNeighbours(Cell cell, Grid currentGrid)
        {
            var neighbours = currentGrid
                .Cells
                .Except(new[] { cell })
                .Intersect(GetSurroundingCells(cell));

            return neighbours.Where(a => a.IsAlive);
        }

        public static IEnumerable<Cell> GetLiveNeighbours(this Grid currentGrid, Cell cell)
        {
            return GetLiveNeighbours(cell, currentGrid);
        }
    }
}