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
    public class AccountPlanRepository : Repository<AccountPlanModel>, IAccountPlanRepository
    {       
        public AccountPlanRepository(MeuDbContext context) : base(context) { }
        
        public async Task<bool> CreateAccount(AccountPlanModel accountPlan)
        {
            try
            {
                if (accountPlan == null)
                {
                    return false;
                }

                await Db.AccountPlans.AddAsync(accountPlan);
                await SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public async Task DeleteAccountPlan(long id)
        {
            try
            {
                var accountPlan = await Db.AccountPlans.FindAsync(id);
                Db.AccountPlans.Remove(accountPlan);
                await SaveChanges();
            }
            catch
            {
            }
        }

        

        public async Task UpdateAccountPlan(AccountPlanModel accountPlan)
        {
            try
            {
                Db.AccountPlans.Update(accountPlan);
                await SaveChanges();
            }
            catch
            {
            }
        }

        public async Task<List<AccountPlanModel>> GetAllAccountPlans()
        {
            return await Db.AccountPlans.ToListAsync();
        }

       
    }
}
