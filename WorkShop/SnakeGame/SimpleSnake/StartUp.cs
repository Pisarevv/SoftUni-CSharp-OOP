﻿using System;
using SimpleSnake.GameObjects;

namespace SimpleSnake
{
    using SimpleSnake.Core;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Field field = new Field(60, 20);
            Snake snake = new Snake(field);

            IEngine engine = new Engine(field, snake);
            engine.Run();
        }
    }
}
