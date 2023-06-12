using Domain.Entities.Recipes.Coctail;
using Domain.Entities.Recipes.Juice;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<CoctailRecipe>> GetAllCoctailsAsync();
        Task<IEnumerable<JuiceRecipe>> GetAllJuicesAsync();
        Task<CoctailRecipe> GetCoctailByIdAsync(int id);
        Task<JuiceRecipe> GetJuiceByIdAsync(int id);
    }
}