using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }
}
