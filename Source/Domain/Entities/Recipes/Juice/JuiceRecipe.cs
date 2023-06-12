using Domain.Recipes;

namespace Domain.Entities.Recipes.Juice
{
    public class JuiceRecipe : IRecipe
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int PricePerGlass { get; set; }
        public string AllowedFruit { get; set; }
        public decimal ConsumptionPerGlass { get; set; }
    }
}
