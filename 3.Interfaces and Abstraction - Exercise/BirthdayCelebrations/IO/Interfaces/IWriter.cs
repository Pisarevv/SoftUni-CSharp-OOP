using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdatCelebrations.IO.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string text);
        void Write(string text);

    }
}
