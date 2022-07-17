using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.IO.Models.Interfaces
{
    public interface IWriter
    {
        public void Write(string text);

        public void WriteLine(string text);
    }
}
