using Domain.Entities;
using Domain.Entities.Recipes.Juice;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;

namespace Blazor.WebSPA.ViewModels
{
    public class JuiceRecipeViewModel : IRecipeViewModel
    {
        public EditContext EditFormContext { get; set; }
        public IEnumerable<JuiceRecipe> Recipes { get; set; }
        public JuiceRecipe Recipe { get; set; }
        public Dictionary<string, int> ItemQuantities { get; set; }
        public string ProductionResult { get; set; }
        public string StatusBG { get; set; }
        public string StatusFC { get; set; }
    }
}
