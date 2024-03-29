﻿using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
    public class MelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Mello, {args[0]}";
        }
    }
}
