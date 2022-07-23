using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
    public class ExitCommand : ICommand
    {
        private int SuccessfulExit = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(SuccessfulExit);

            return null;
        }
    }
}
