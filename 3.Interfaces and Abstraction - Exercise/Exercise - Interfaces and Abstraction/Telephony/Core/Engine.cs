namespace Telephony.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Telephony.IO.Interfaces;
    using Telephony.Models;
    using Telephony.Models.Interfaces;

    internal class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly Smartphone smartphone;
        private readonly StationaryPhone stationaryPhone;
        private Engine()
        {
            smartphone = new Smartphone();
            stationaryPhone = new StationaryPhone();
        }
        public Engine(IReader reader, IWriter writer):this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Start()
        {
            string[] numbersInput = reader.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string[] urlsInput = reader.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string number in numbersInput)
            {
                if (ValidateNumber(number))
                {
                    if (number.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        writer.WriteLine(smartphone.Call(number));
                    }
                }
                else
                {
                    writer.WriteLine("Invalid number!");
                }
            }

            foreach (string url in urlsInput)
            {
                if (ValidateUrl(url))
                {
                    writer.WriteLine(smartphone.Browse(url));
                }
                else
                {
                    writer.WriteLine("Invalid URL!");
                }
            }
        }

        private bool ValidateNumber(string number)
        {
            foreach (char c in number)
            {
                if (Char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateUrl (string url)
        {
            foreach (char c in url)
            {
                if (Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
