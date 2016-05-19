using System.Collections.Generic;
using System.Linq;
using GameOfLife.Utilities;

namespace GameOfLife
{
    public class Life
    {
        public Life(int size, IEnumerable<Cell> liveCells)
        {
            Grid = new Grid(size, liveCells);
        }

        public Grid Grid { get; private set; }

        public void RunLifeCycle()
        {
            var nextGeneration = new List<Cell>(Grid.Cells.Where(a => a.IsAlive));

            foreach (var cell in Grid.Cells.Where(a => a.IsAlive))
            {
                var neighbours = Grid.GetLiveNeighbours(cell).ToArray();
                if (neighbours.Length < 2)
                {
                    nextGeneration.Remove(cell);
                }

                if (new[] { 2, 3 }.Contains(neighbours.Length))
                {
                    continue;
                }

                if (neighbours.Length > 3)
                {
                    nextGeneration.Remove(cell);
                }
            }

            foreach (var deadCell in Grid.Cells.Where(a => !a.IsAlive))
            {
                var neighbours = Grid.GetLiveNeighbours(deadCell).ToArray();
                if (neighbours.Length == 3)
                {
                    nextGeneration.Add(Cell.CreateLive(deadCell.X, deadCell.Y));
                }
            }

            Grid = new Grid(Grid.Size, nextGeneration);
        }
    }
}