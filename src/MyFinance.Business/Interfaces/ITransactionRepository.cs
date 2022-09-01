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
    }
}
