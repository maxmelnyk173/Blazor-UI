using FinanceManager.web.Data;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinanceManager.web.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly HttpClient httpClient;

        public TransactionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await httpClient.GetJsonAsync<List<Transaction>>("api/transactions");
        }

        public async Task<Transaction> GetByIdAsync(int id)
        {
            return await httpClient.GetJsonAsync<Transaction>($"api/transactions/{id}");
        }

        public async Task<Transaction> SaveAsync(Transaction obj)
        {
            return await httpClient.PostJsonAsync<Transaction>("api/transactions", obj);
        }

        public async Task UpdateAsync(int id, Transaction obj)
        {
            await httpClient.PutJsonAsync($"api/transactions/{id}", obj);
        }

        public async Task<string> DeleteAsync(int id)
        {
            var result = await httpClient.DeleteAsync($"api/transactions/{id}");
            return result.StatusCode.ToString();
        }

        public async Task<IEnumerable<Transaction>> GetDailyReport(string date)
        {
            return await httpClient.GetJsonAsync<List<Transaction>>($"api/transactions/report/Date={date}");
        }

        public async Task<IEnumerable<Transaction>> GetMonthReport(string startDate, string endDate)
        {
            return await httpClient.GetJsonAsync<List<Transaction>>($"api/transactions/report/StartDate={startDate}&EndDate={endDate}");
        }
    }
}
