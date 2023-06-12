using Domain.Entities.Recipes.Juice;
using System.Collections.Generic;

namespace Domain.Services.Juice
{
    public interface IFruitPressService
    {
        Dictionary<string, decimal> GenerateFruitDictionary(decimal appleQuantity, decimal melonQuantity, decimal orangeQuantity);
        List<string> Produce(JuiceRecipe recipe, Dictionary<string, decimal> fruits, int moneyPaid, int orderedGlassQuantity);
    }
}