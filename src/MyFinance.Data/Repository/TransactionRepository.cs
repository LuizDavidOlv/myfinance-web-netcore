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

        public async Task<bool> CreateTransaction(TransactionModel transaction)
        {
            try
            {
                await Db.Transactions.AddAsync(transaction);
                await this.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTransaction(TransactionModel transaction)
        {
            Db.Transactions.Update(transaction);
            await SaveChanges();

            return true;
        }

        public async Task DeleteTransaction(long id)
        {
            try
            {
                var transaction = await Db.Transactions.FindAsync(id);
                Db.Transactions.Remove(transaction);
                await SaveChanges();
            }
            catch
            {
            }
        }

        public async Task<TransactionReportModel> GetTransactionsByDate(TransactionReportModel model)
        {
            try
            {
               
                var filteredTransactions = await Db.Transactions.Where(p => p.Date >= model.StartDate && p.Date <= model.EndDate).ToListAsync();
                //add filteredTransactions list into model
                foreach (var transaction in filteredTransactions)
                {
                    model.Transacoes.Add(transaction);
                }

            }
            catch(Exception ex)
            {
                
            }
            return model;
        }
    }
}
