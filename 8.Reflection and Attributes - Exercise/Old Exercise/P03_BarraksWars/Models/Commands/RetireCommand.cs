using _03BarracksFactory.Contracts;
using P03_BarraksWars.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Models.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

 
        public override string Execute()
        {
            string unitType = data[1];
            repository.RemoveUnit(unitType);

        }
    }
}
