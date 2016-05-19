namespace GameOfLife
{
    internal static class LifeStartingShapes
    {
        internal static readonly Cell[] Toad = new Cell[]
        {
            Cell.CreateLive(5, 4),
            Cell.CreateLive(5, 5),
            Cell.CreateLive(5, 6),
            Cell.CreateLive(6, 3),
            Cell.CreateLive(6, 4),
            Cell.CreateLive(6, 5),
        };

        internal static readonly Cell[] Blinker = new Cell[]
        {
            Cell.CreateLive(5, 4),
            Cell.CreateLive(5, 5),
            Cell.CreateLive(5, 6),
        };

        internal static readonly Cell[] FiveCellRow =
        {
            Cell.CreateLive(5, 5),
            Cell.CreateLive(5, 6),
            Cell.CreateLive(5, 7),
            Cell.CreateLive(5, 8),
            Cell.CreateLive(5, 9)
        };

        internal static readonly Cell[] Glider =
        {
            Cell.CreateLive(5, 5),
            Cell.CreateLive(5, 6),
            Cell.CreateLive(5, 7),
            Cell.CreateLive(4, 7),
            Cell.CreateLive(3, 6)
        };
    }
}