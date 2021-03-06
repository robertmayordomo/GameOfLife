using System;
using System.Linq;
using GameOfLife.GameModels;
using NUnit.Framework;

namespace Tests
{
    public class GridTests
    {
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(122)]
        public void ShouldGenerateCorrectGrid(int size)
        {
            //arrange
            var zeroColumnCount = (size * 4) + 1;
            var expectedCellCount = Math.Pow((size) * 2, 2) + zeroColumnCount;

            //act
            var actual = new Grid(size, Enumerable.Empty<Cell>()).Cells.ToArray();

            //assert	        
            Assert.That(actual.Length, Is.EqualTo(expectedCellCount));
            Console.WriteLine($"Size: {size}, Exptected: {expectedCellCount}, Actual: {actual.Length}");
        }

        [Test]
        public void MergeShouldLeaveLiveCellsIntact()
        {
            //arrange
            var liveCells = new[] { Cell.CreateLive(0, 0) };

            //act
            var remainingLiveCells = new Grid(1, liveCells).Cells.Where(a => a.IsAlive).ToArray();

            //assert
            CollectionAssert.IsNotEmpty(remainingLiveCells);
            Assert.That(remainingLiveCells.Count(a => a.IsAlive), Is.EqualTo(1));

        }

        [Test]
        public void ShouldGenerateFullGrid()
        {
            //arrange
            var liveCells = new[] { Cell.CreateLive(0, 0), Cell.CreateLive(9, 0) };
            const int size = 10;
            const int zeroColumnCount = (size * 4) + 1;
            var expectedCellCount = Math.Pow((size) * 2, 2) + zeroColumnCount;

            //act
            var allCells = new Grid(size, liveCells).Cells.ToArray();

            //assert
            CollectionAssert.IsNotEmpty(allCells);
            Assert.That(allCells.Length, Is.EqualTo(expectedCellCount));
            Assert.That(allCells.Count(a => a.IsAlive), Is.EqualTo(liveCells.Length));

            var deadCells = allCells.Count(a => !a.IsAlive);
            Assert.That(deadCells, Is.EqualTo(expectedCellCount - liveCells.Length));
        }
    }
}