namespace Domain.Recipes
{
    public interface IRecipe
    {
        int Id { get; set; }
        string Image { get; set; }
        string Name { get; set; }
        int PricePerGlass { get; set; }
    }
}
