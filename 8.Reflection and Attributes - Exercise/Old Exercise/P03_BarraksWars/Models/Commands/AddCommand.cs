using _03BarracksFactory.Contracts;
using P03_BarraksWars.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Models.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
