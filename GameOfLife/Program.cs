﻿using System;
using GameOfLife.Utilities;

namespace GameOfLife
{
    internal class Program
    {
        private static readonly ConsoleGridWriter ConsoleGridWriter = new ConsoleGridWriter();

        private static void Main(string[] args)
        {
            var gameOfLifeEmulator = new Life(10, LifeStartingShapes.Toad);

            ConsoleGridWriter.Write(gameOfLifeEmulator.Grid);

            for (var i = 0; i < 10; i++)
            {
                gameOfLifeEmulator.RunLifeCycle();
                ConsoleGridWriter.Write(gameOfLifeEmulator.Grid);
            }

            Console.ReadKey();
        }
    }
}