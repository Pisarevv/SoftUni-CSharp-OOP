﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> models;
        public FormulaOneCarRepository()
        {
            this.models = new HashSet<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)models;

        public void Add(IFormulaOneCar model)=> this.models.Add(model);

        public bool Remove(IFormulaOneCar model)=> this.models.Remove(model);

        public IFormulaOneCar FindByName(string model) => this.models.FirstOrDefault(x => x.Model == model);
    

       
    }
}
