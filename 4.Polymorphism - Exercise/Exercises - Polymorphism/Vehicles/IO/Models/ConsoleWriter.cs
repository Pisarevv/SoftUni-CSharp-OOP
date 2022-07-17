using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.IO.Models.Interfaces;

namespace Vehicles.IO.Models
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
