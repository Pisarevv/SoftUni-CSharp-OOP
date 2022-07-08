using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;
        private readonly Dictionary<string, double> flourTypeDic = new Dictionary<string, double>()
        {   
            ["white"] = 1.5,
            ["wholegrain"] = 1.0
        };
        private readonly Dictionary<string, double> bakingTechniqueDic = new Dictionary<string, double>()
        {          
            ["crispy"] = 0.9,
            ["chewy"] = 1.1,
            ["homemade"] = 1.0
        };
        private double grams;
        private string flourType;
        private string bakingTechnique;
        private double totalCalories;

        public Dough(string doughtType,string bakingTechnique,double grams)
        {
            this.FlourType = doughtType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
            CalculateTotalCalories();
        }
        public double Grams
        {
            get
            {
                return grams;
            }
            private set
            {
                if(value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value;
            }
        }
        public string FlourType
        {
            get
            {
                return flourType;
            }
            private set
            {
                if (!flourTypeDic.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                if (!bakingTechniqueDic.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double TotalCalories
        {
            get { return totalCalories; }
        }

        private void CalculateTotalCalories()
        {
            double flourCalories = flourTypeDic[this.FlourType.ToLower()];
            double techniqueCalories = bakingTechniqueDic[this.BakingTechnique.ToLower()];
            this.totalCalories = (BaseCaloriesPerGram * this.Grams) * flourCalories * techniqueCalories;
        }

    }
}
