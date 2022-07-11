using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.IO.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string text);
        void Write(string text);

    }
}
