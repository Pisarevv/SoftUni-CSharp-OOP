﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Models.Interfaces
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
