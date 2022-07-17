using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.IO.Models.Interfaces;

namespace WildFarm.IO.Models
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
