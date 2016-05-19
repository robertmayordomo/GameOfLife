using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using GameOfLife;
using GameOfLife.Utilities;
using NUnit.Framework;

namespace Tests
{
    public class GameOfLifeTests
    {
        private Life _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Life(0, Enumerable.Empty<Cell>());
        }

        [Test]
        public void ShouldInitializeGrid()
        {
            //arrange
            const int size = 10;

            //act
            _sut = new Life(size, Enumerable.Empty<Cell>());

            //assert	        
            Assert.That(_sut.Grid.Size, Is.EqualTo(size));
        }

        [Test]
        public void ShouldSetInitialState()
        {
            //arrange
            const int size = 10;
            var cells = new[]
            {
                Cell.CreateLive(0, 0),
                Cell.CreateLive(0, 1),
                Cell.CreateLive(3, 4)
            };

            //act
            _sut = new Life(size, cells);

            //assert
            CollectionAssert.AreEquivalent(_sut.Grid.Cells, cells);
        }

        [Test]
        public void AllCellsShouldDieFromUnderPopulation()
        {
            //arrange
            const int size = 10;
            var cells = new[]
            {
                Cell.CreateLive(0, 0),
                Cell.CreateLive(0, 1),
                Cell.CreateLive(0, 10),
                Cell.CreateLive(3, 4)
            };

            //act
            _sut = new Life(size, cells);
            _sut.RunLifeCycle();

            //assert
            CollectionAssert.IsEmpty(_sut.Grid.Cells.Where(a => a.IsAlive));
        }
    }

    public class CellHelperTests
    {
        [Test]
        public void ShouldHaveNoNeighbours()
        {
            //arrange
            var cells = new[]
            {
                Cell.CreateLive(0, 0),
                Cell.CreateLive(0, 1),
                Cell.CreateLive(3, 4),
                Cell.CreateLive(6, 0)
            };

            //act
            var actual = CellHelper.GetLiveNeighbours(cells.Last(), new Grid(10, cells));

            //assert	
            CollectionAssert.IsEmpty(actual);
        }


        [Test]
        public void ShouldHaveOneNeighbours()
        {
            //arrange
            var cells = new[]
            {
                Cell.CreateLive(0, 0),
                Cell.CreateLive(0, 1),
                Cell.CreateLive(3, 4),
                Cell.CreateLive(6, 0)
            };

            //act
            var actual = CellHelper.GetLiveNeighbours(cells.First(), new Grid(10, cells));

            //assert	
            Assert.That(actual.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ShouldHaveTwoNeighbours()
        {
            //arrange
            var cells = new[]
            {
                Cell.CreateLive(0, 0),
                Cell.CreateLive(0, 1),
                Cell.CreateLive(-1, 0),
                Cell.CreateLive(3, 4),
                Cell.CreateLive(6, 0)
            };

            //act
            var actual = CellHelper.GetLiveNeighbours(cells.First(), new Grid(10, cells));

            //assert	
            Assert.That(actual.Count(), Is.EqualTo(2));
        }

        [Test]
        public void ShouldHaveThreeNeighbours()
        {
            //arrange
            var cells = new[]
            {
                Cell.CreateLive(0, 0),
                Cell.CreateLive(0, 1),
                Cell.CreateLive(-1, 0),
                Cell.CreateLive(-1, -1),
                Cell.CreateLive(3, 4),
                Cell.CreateLive(6, 0)
            };

            //act
            var actual = CellHelper.GetLiveNeighbours(cells.First(), new Grid(10, cells));

            //assert	
            Assert.That(actual.Count(), Is.EqualTo(3));
        }

        [Test]
        public void ShouldHaveFourNeighbours()
        {
            //arrange
            var cells = new[]
            {
                Cell.CreateLive(0, 0),
                Cell.CreateLive(0, 1),
                Cell.CreateLive(-1, 0),
                Cell.CreateLive(-1, -1),
                Cell.CreateLive(+1, +1),
                Cell.CreateLive(3, 4),
                Cell.CreateLive(6, 0)
            };

            //act
            var actual = CellHelper.GetLiveNeighbours(cells.First(), new Grid(10, cells));

            //assert	
            Assert.That(actual.Count(), Is.EqualTo(4));
        }

    }


    public class CellHelperDeadCellGenerationTests
    {
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(122)]
        public void ShouldGenerateCorrectGrid(int size)
        {
            //arrange
            var expectedCellCount = Math.Pow(size, 2);

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
            var size = 10;
            var totalGridSize = Math.Pow(size, 2);

            //act
            var allCells = new Grid(size, liveCells).Cells.ToArray();

            //assert
            CollectionAssert.IsNotEmpty(allCells);
            Assert.That(allCells.Length, Is.EqualTo(totalGridSize));
            Assert.That(allCells.Count(a => a.IsAlive), Is.EqualTo(liveCells.Length));

            var deadCells = allCells.Count(a => !a.IsAlive);
            Assert.That(deadCells, Is.EqualTo(totalGridSize - liveCells.Length));
        }
    }

    public class LinqExtensionsTests
    {
        [Test]
        public void ShouldOverWrite()
        {
            //arrange
            var liveCells = new[] { Cell.CreateLive(0, 0) };
            var deadCells = new[] { Cell.CreateDead(0, 0) };

            //act

            var actual = deadCells.ReplaceAll(liveCells, cell => cell.IsAlive).ToArray();

            //assert	        
            Assert.That(actual.Count(), Is.EqualTo(1));
            CollectionAssert.AreEquivalent(actual, liveCells);
        }

        [Test]
        public void ShouldOverWriteOnlyValidDeadCells()
        {
            //arrange
            var liveCells = new[] { Cell.CreateLive(0, 0) };
            var deadCells = new[] { Cell.CreateDead(0, 0), Cell.CreateDead(0, 1) };

            //act

            var actual = deadCells.ReplaceAll(liveCells, cell => cell.IsAlive).ToArray();

            //assert	        
            Assert.That(actual.Length, Is.EqualTo(2));
            Assert.That(actual.Count(a => a.IsAlive), Is.EqualTo(1));
            Assert.That(actual.Count(a => !a.IsAlive), Is.EqualTo(1));
        }
    }
}