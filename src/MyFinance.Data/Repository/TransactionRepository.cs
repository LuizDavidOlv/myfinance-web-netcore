using Microsoft.EntityFrameworkCore;
using MyFinance.Business.Interfaces;
using MyFinance.Business.Models;
using MyFinance.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Data.Repository
{
    public class TransactionRepository : Repository<TransactionModel>, ITransactionRepository
    {
        public TransactionRepository(MeuDbContext context) : base(context) { }
        public async Task<List<TransactionModel>> GetAllAccountPlans()
        {
            return await Db.Transactions.ToListAsync();
        }
    }
}
