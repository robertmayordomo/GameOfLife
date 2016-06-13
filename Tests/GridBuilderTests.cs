using System.Linq;
using GameOfLife.Utilities;
using NUnit.Framework;

namespace Tests
{
    public class GridBuilderTests
    {
        [TestCase(2)]
        [TestCase(8)]
        [TestCase(12)]
        [TestCase(200)]
        public void ShouldHaveEqualSizes(int size)
        {

            //act
            var grid = GridBuilder.GenerateGrid(size);


            //assert
            var minXAxis = grid.Min(a => a.X);
            var minYAxis = grid.Min(a => a.Y);

            var maxXAxis = grid.Max(a => a.X);
            var maxYAxis = grid.Max(a => a.Y);



            Assert.That(minXAxis, Is.EqualTo(-size));
            Assert.That(minYAxis, Is.EqualTo(-size));

            Assert.That(maxXAxis, Is.EqualTo(size));
            Assert.That(maxYAxis, Is.EqualTo(size));
        }

        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(11)]
        public void ShouldRoundUpToEqualSizes(int size)
        {
            var grid = GridBuilder.GenerateGrid(size);

            var minXAxis = grid.Min(a => a.X);
            var minYAxis = grid.Min(a => a.Y);

            var maxXAxis = grid.Max(a => a.X);
            var maxYAxis = grid.Max(a => a.Y);


            Assert.That(minXAxis, Is.EqualTo(-size));
            Assert.That(minYAxis, Is.EqualTo(-size));

            Assert.That(maxXAxis, Is.EqualTo(size));
            Assert.That(maxYAxis, Is.EqualTo(size));
        }

    }
}