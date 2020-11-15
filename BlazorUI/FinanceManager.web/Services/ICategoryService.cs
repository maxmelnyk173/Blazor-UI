using FinanceManager.web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceManager.web.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category> GetByIdAsync(int id);

        Task<Category> SaveAsync(Category obj);

        Task UpdateAsync(int id, Category obj);

        Task<string> DeleteAsync(int Id);
    }
}
