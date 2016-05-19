using System;
using System.Linq;

namespace GameOfLife.Utilities
{
    public sealed class ConsoleGridWriter : IGridWriter
    {
        public ConsoleGridWriter()
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);
        }

        public void Write(Grid grid)
        {
            for (var x = 0; x < grid.Size; x++)
            {
                for (var y = 0; y < grid.Size; y++)
                {
                    if (grid.Cells.Single(a => a.X == x && a.Y == y).IsAlive)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write((char)219);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write((char)219);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}