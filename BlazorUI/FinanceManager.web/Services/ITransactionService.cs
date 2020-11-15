using FinanceManager.web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceManager.web.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllAsync();

        Task<Transaction> GetByIdAsync(int Id);

        Task<Transaction> SaveAsync(Transaction obj);

        Task UpdateAsync(int Id, Transaction obj);

        Task<string> DeleteAsync(int Id);

        Task<IEnumerable<Transaction>> GetDailyReport(string date);

        Task<IEnumerable<Transaction>> GetMonthReport(string startDate, string endDate);
    }
}
