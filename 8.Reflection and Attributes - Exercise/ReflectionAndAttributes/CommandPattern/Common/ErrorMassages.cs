﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Common
{
    public static class ErrorMassages
    {
        public const string InvalidCommandType = "Provided type {0} does not exist or it does not implement ICommand Interface!";
    }
}
