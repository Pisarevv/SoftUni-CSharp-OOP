using _03BarracksFactory.Contracts;
using P03_BarraksWars.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Models.Commands
{
    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
