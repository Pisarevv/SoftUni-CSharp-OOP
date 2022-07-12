using FoodShortage.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.IO
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
