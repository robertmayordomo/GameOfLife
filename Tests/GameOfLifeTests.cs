using System.Linq;
using GameOfLife;
using GameOfLife.GameModels;
using NUnit.Framework;

namespace Tests
{
    public class GameOfLifeTests
    {
        [Test]
        public void ShouldInitializeGrid()
        {
            //arrange
            const int size = 10;

            //act
            var sut = new Life(size, Enumerable.Empty<Cell>());

            //assert	        
            Assert.That(sut.Grid.Size, Is.EqualTo(size));
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
            var sut = new Life(size, cells);

            //assert
            CollectionAssert.AreEquivalent(sut.Grid.Cells.Where(a => a.IsAlive), cells);
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
            var sut = new Life(size, cells);
            sut.RunLifeCycle();

            //assert
            CollectionAssert.IsEmpty(sut.Grid.Cells.Where(a => a.IsAlive));
        }
    }
}