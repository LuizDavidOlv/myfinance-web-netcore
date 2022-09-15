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
        Task<TransactionReportViewModel> GetTransactionsByDate(TransactionReportModel model);
        public int CountDebit(TransactionReportViewModel model);
        public int CountCredit(TransactionReportViewModel model);
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

        public async Task<TransactionReportViewModel> GetTransactionsByDate(TransactionReportModel model)
        {
            TransactionReportViewModel finalResponse = new TransactionReportViewModel();
            try
            {
                TransactionReportModel firstResponse = await this.transactionRepository.GetTransactionsByDate(model);
                
                finalResponse.StartDate = model.StartDate;
                finalResponse.EndDate = model.EndDate;
                foreach(var transaction in firstResponse.Transacoes)
                {
                    //add transation in  finalResponse
                    finalResponse.Transactions.Add(new TransactionViewModel()
                    {
                        Id = transaction.Id,
                        Date = transaction.Date,
                        Value = transaction.Value,
                        Type = transaction.Type,
                        History = transaction.History,
                        AccountPlanId = transaction.AccountPlanId
                    });
                }


            }
            catch (Exception ex)
            {
               
            }
            return finalResponse;
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

        public int CountDebit(TransactionReportViewModel model)
        {
            int response = 0;
            foreach(var compras in model.Transactions)
            {
                if(compras.Type =="2")
                {
                    response++;
                }
            }
            return response;
        }

        public int CountCredit(TransactionReportViewModel model)
        {
            int response = 0;
            foreach (var compras in model.Transactions)
            {
                if (compras.Type == "1")
                {
                    response++;
                }
            }
            return response;

        }
    }
}
