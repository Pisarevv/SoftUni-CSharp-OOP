namespace BorderControl
{
    using BorderControl.Core;
    using BorderControl.IO;
    using BorderControl.IO.Interfaces;
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
