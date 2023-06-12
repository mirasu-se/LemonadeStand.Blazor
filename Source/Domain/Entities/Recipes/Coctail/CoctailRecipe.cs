using Domain.Recipes;
using System.Collections.Generic;

namespace Domain.Entities.Recipes.Coctail
{
    public class CoctailRecipe : IRecipe
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int PricePerGlass { get; set; }
        public int GlassQuantityPerMix { get; set; }
        public List<CoctailQuantity> CoctailQuantity { get; set; }
    }
}
