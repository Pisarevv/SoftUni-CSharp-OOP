using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.IO.Models.Interfaces;

namespace Vehicles.IO.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
