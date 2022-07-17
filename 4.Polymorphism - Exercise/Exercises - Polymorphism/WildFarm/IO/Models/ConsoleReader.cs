using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.IO.Models.Interfaces;

namespace WildFarm.IO.Models
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
