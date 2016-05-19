using System.Collections.Generic;
using System.Linq;
using GameOfLife.Utilities;

namespace GameOfLife.GameModels
{
    public sealed class Grid
    {
        public int Size { get; }
        public IEnumerable<Cell> Cells { get; }

        public Grid(int size, IEnumerable<Cell> cells)
        {
            Size = size;
            Cells = AddLiveToGrid(size, cells.ToArray());
        }

        private static IEnumerable<Cell> AddLiveToGrid(int size, Cell[] liveCells)
        {
            var deadCellGrid = GridBuilder.GenerateGrid(size);

            foreach (var cell in deadCellGrid)
            {
                var liveCell = liveCells.SingleOrDefault(a => a.Equals(cell));
                if (liveCell != null)
                {
                    yield return liveCell;
                    continue;
                }
                yield return cell;
            }
        }
    }
}