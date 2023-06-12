using Domain.Entities.Recipes.Coctail;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.WebSPA.ViewModels.Coctail
{
    public class CoctailRecipeViewModel
    {
        public EditContext EditFormContext { get; set; }
        public IEnumerable<CoctailRecipe> Recipes { get; set; }
        public CoctailRecipe Recipe { get; set; }
        public Dictionary<string, int> ItemQuantities { get; set; }
        public string ProductionResult { get; set; }
        public string StatusBG { get; set; }
        public string StatusFC { get; set; }
    }
}
