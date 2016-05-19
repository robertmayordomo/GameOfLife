using System.Linq;
using GameOfLife.GameModels;
using GameOfLife.Utilities;
using NUnit.Framework;

namespace Tests
{
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
}