using MyFinance.App.ViewModels;
using MyFinance.Business.Interfaces;
using MyFinance.Business.Models;

namespace MyFinance.App.Services
{
    public interface ITransactionService
    {
        Task<bool> CreateTransaction(TransactionViewModel transactionViewModel);
        Task<List<TransactionViewModel>> GetAllTransactions();
        Task<bool> DeleteTransaction(long id);
        Task<bool> UpdateTransaction(TransactionViewModel form);
        Task<bool> GetTransactionsByDate(TransactionReportViewModel model);
    }
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public async Task<bool> CreateTransaction(TransactionViewModel transactionViewModel)
        {
            try
            {
                TransactionModel transaction = new TransactionModel();

                transaction.Id = 0;
                transaction.Value = transactionViewModel.Value;
                transaction.Date = transactionViewModel.Date;
                transaction.AccountPlanId = transactionViewModel.AccountPlanId;
                transaction.Type = transactionViewModel.Type;
                transaction.History = transactionViewModel.History;

                await this.transactionRepository.CreateTransaction(transaction);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteTransaction(long id)
        {
            try
            {

                await this.transactionRepository.DeleteTransaction(id);

                return true;
            }
            catch
            {
                return false;
            }
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

        public async Task<bool> GetTransactionsByDate(TransactionReportViewModel model)
        {
            //montar model
            await this.transactionRepository.GetTransactionsByDate(null);

            return true;
        }

        public async Task<bool> UpdateTransaction(TransactionViewModel form)
        {
            try
            {
                TransactionModel transaction = new TransactionModel();

                transaction.Id = form.Id;
                transaction.AccountPlanId = form.AccountPlanId;
                transaction.Value = form.Value;
                transaction.History = form.History;
                transaction.Date = form.Date;
                transaction.Type = form.Type;

                await this.transactionRepository.UpdateTransaction(transaction);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
