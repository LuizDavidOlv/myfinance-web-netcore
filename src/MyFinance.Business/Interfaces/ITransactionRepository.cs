using MyFinance.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Business.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<TransactionModel>> GetAllAccountPlans();
        Task<bool> CreateTransaction(TransactionModel transaction);
        Task<bool> UpdateTransaction(TransactionModel transaction);
        Task<TransactionReportModel> GetTransactionsByDate(TransactionReportModel model);
        Task DeleteTransaction(long id);
    }
}
