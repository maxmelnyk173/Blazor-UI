using FinanceManager.web.Data;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinanceManager.web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;

        public CategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await httpClient.GetJsonAsync<List<Category>>("api/categories");
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await httpClient.GetJsonAsync<Category>($"api/categories/{id}");
        }

        public async Task<Category> SaveAsync(Category obj)
        {
            return await httpClient.PostJsonAsync<Category>("api/categories", obj);
        }

        public async Task UpdateAsync(int id, Category obj)
        {
            await httpClient.PutJsonAsync($"api/categories/{id}", obj);
        }

        public async Task<string> DeleteAsync(int id)
        {
            var result = await httpClient.DeleteAsync($"api/categories/{id}");
            return result.StatusCode.ToString();
        }
    }
}
