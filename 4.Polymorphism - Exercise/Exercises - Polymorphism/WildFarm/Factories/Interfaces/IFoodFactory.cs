using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Factories.Interfaces
{
    //TODO: Inplement factories

    public interface IFoodFactory
    {
        FoodFactory CreateFood(int quantity);
    }
}
