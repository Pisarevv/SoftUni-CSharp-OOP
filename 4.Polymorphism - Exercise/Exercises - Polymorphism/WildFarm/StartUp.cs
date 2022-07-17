using System;
using WildFarm.Core;
using WildFarm.IO.Models;
using WildFarm.IO.Models.Interfaces;

namespace WildFarm
{
    internal class Program
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine Engine = new Engine(reader,writer);
            Engine.Start();

        }
    }
}
