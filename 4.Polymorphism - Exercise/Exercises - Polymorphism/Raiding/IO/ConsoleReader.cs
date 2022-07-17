using Raiding.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string text = Console.ReadLine();
            
            
            
            return text;
        }
    }
}
