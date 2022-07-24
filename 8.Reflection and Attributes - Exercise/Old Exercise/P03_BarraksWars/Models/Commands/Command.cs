using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Data
{
    public abstract class Command : IExecutable
    {
        protected string[] data;
        protected IRepository repository;
        protected IUnitFactory unitFactory;

        protected Command (string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            Data = data;
            Repository = repository;
            UnitFactory = unitFactory;
        }

        public string[] Data
        {
            get { return data; }
            private set { data = value; }
        }
        public IRepository Repository
        {
            get { return repository; }
            private set { repository = value; }
        }
        public IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            private set
            {
                unitFactory = value;
            }
        }
        public abstract string Execute();
    }
}
