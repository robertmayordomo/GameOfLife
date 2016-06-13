using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GameOfLife.GameModels;
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

            var newGridSize = GetNewGridSize(nextGeneration);

            Grid = new Grid(Math.Max(newGridSize, Grid.Size), nextGeneration);
        }

        private static int GetNewGridSize(IReadOnlyCollection<Cell> nextGeneration)
        {
            if (!nextGeneration.Any())
                return 0;

            var min = Math.Min(nextGeneration.Min(a => a.X), nextGeneration.Min(a => a.Y));
            var max = Math.Max(nextGeneration.Max(a => a.X), nextGeneration.Max(a => a.Y));

            var minDistance = Math.Abs(0 - min);
            var newGridSize = minDistance > max ? min : max;
            return newGridSize+2;
        }
    }
}