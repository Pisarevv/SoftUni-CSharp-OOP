namespace BirthdatCelebrations
{
    using BirthdatCelebrations.Core;
    using BirthdatCelebrations.IO;
    using BirthdatCelebrations.IO.Interfaces;
    using System;

    public class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader,writer);
            engine.Start();

        }
    }
}
