using System;
using System.Linq;
using GameOfLife;
using GameOfLife.GameModels;
using GameOfLife.Utilities;

namespace Tests
{
    public class FakeWriter : IGridWriter
    {
        public void Write(Grid grid)
        {
            var orderedGrid = grid.Cells.OrderBy(a => a.X).ThenBy(a => a.Y);

            foreach (var cell in orderedGrid)
            {
                Console.Write(cell);
            }
        }
    }
}