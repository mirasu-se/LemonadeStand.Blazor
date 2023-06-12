using Domain.Entities.Recipes.Coctail;
using Domain.Entities.Recipes.Juice;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class RecipeService : IRecipeService
    {
        private static readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:44323/")
        };

        public async Task<IEnumerable<JuiceRecipe>> GetAllJuicesAsync()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using var request = new HttpRequestMessage(HttpMethod.Get, "/api/juice/juices.json");
            using var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var juices = await response.Content.ReadFromJsonAsync<IEnumerable<JuiceRecipe>>();
            return juices;
        }

        public async Task<JuiceRecipe> GetJuiceByIdAsync(int id)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using var request = new HttpRequestMessage(HttpMethod.Get, "/api/juice/" + id + "/juice.json");
            using var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var juices = await response.Content.ReadFromJsonAsync<List<JuiceRecipe>>();

            JuiceRecipe juice = new()
            {
                Id = juices[0].Id,
                Name = juices[0].Name,
                Image = juices[0].Image,
                PricePerGlass = juices[0].PricePerGlass,
                ConsumptionPerGlass = juices[0].ConsumptionPerGlass,
                AllowedFruit = juices[0].AllowedFruit
            };

            return juice;
        }

        public async Task<IEnumerable<CoctailRecipe>> GetAllCoctailsAsync()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using var request = new HttpRequestMessage(HttpMethod.Get, "/api/coctail/coctails.json");
            using var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var coctails = await response.Content.ReadFromJsonAsync<IEnumerable<CoctailRecipe>>();
            return coctails;
        }

        public async Task<CoctailRecipe> GetCoctailByIdAsync(int id)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using var request = new HttpRequestMessage(HttpMethod.Get, "/api/coctail/" + id + "/coctail.json");
            using var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var coctails = await response.Content.ReadFromJsonAsync<List<CoctailRecipe>>();

            CoctailRecipe coctail = new()
            {
                Id = coctails[0].Id,
                Name = coctails[0].Name,
                Image = coctails[0].Image,
                PricePerGlass = coctails[0].PricePerGlass,
                GlassQuantityPerMix = coctails[0].GlassQuantityPerMix,
                CoctailQuantity = coctails[0].CoctailQuantity
            };

            return coctail;
        }
    }
}
