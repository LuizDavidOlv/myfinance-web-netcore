using MyFinance.App.ViewModels;
using MyFinance.Business.Interfaces;
using MyFinance.Business.Models;

namespace MyFinance.App.Services
{
    public interface ITransactionService
    {
        Task<bool> CreateTransaction(TransactionViewModel transactionViewModel);
        Task<List<TransactionViewModel>> GetAllTransactions();
        Task<bool> DeleteTransaction(int id);
        Task<bool> UpdateTransaction(TransactionViewModel id);
    }
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public Task<bool> CreateTransaction(TransactionViewModel transactionViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTransaction(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TransactionViewModel>> GetAllTransactions()
        {
            try
            {
                var response = await this.transactionRepository.GetAllAccountPlans();

                List<TransactionViewModel> accountPlans = new List<TransactionViewModel>();

                foreach (var item in response)
                {
                    accountPlans.Add(new TransactionViewModel()
                    {
                        Id = item.Id,
                        Date = item.Date,
                        Value = item.Value,
                        Type = item.Type,
                        History = item.History,
                        AccountPlanId = item.AccountPlanId

                    });
                }

                return accountPlans;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> UpdateTransaction(TransactionViewModel id)
        {
            throw new NotImplementedException();
        }
    }
}
