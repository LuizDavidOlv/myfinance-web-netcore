using MyFinance.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Business.Interfaces
{
    public interface IAccountPlanRepository : IRepository<AccountPlanModel>
    {
        Task<bool> CreateAccount(AccountPlanModel accountPlan);
        Task<List<AccountPlanModel>> GetAllAccountPlans();
        Task DeleteAccountPlan(long id);
        Task UpdateAccountPlan(AccountPlanModel form);
    }
}
