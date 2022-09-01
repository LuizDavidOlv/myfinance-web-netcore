﻿using MyFinance.App.ViewModels;
using MyFinance.Business.Interfaces;
using MyFinance.Business.Models;

namespace MyFinance.App.Services
{
    public interface IAccountPlanService
    {
        Task<bool> CreateAccountPlan(AccountPlanViewModel accountPlanViewModel);
        Task<List<AccountPlanViewModel>> GetAllAccountPlans();
        Task<bool> DeleteAccountPlan(int id);
        Task<bool> UpdateAccountPlan(AccountPlanViewModel id);
    }

    public class AccountPlanService : IAccountPlanService
    {
        private readonly IAccountPlanRepository accountPlanRepository;

        public AccountPlanService(IAccountPlanRepository accountPlanRepository)
        {
            this.accountPlanRepository = accountPlanRepository;
        }
        
        public async Task<bool> CreateAccountPlan(AccountPlanViewModel accountPlanViewModel)
        {
            try
            {
                if (accountPlanViewModel == null)
                {
                    throw new ArgumentNullException(nameof(accountPlanViewModel));
                }

                AccountPlanModel accountPlan = new AccountPlanModel();
                
                accountPlan.Id = 0;
                accountPlan.Description = accountPlanViewModel.Description;
                accountPlan.Type = accountPlanViewModel.Type;

                var a = await this.accountPlanRepository.CreateAccount(accountPlan);
                    
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdateAccountPlan(AccountPlanViewModel form)
        {
            try
            {              
                AccountPlanModel accountPlan = new AccountPlanModel();

                accountPlan.Id = form.Id;
                accountPlan.Description = form.Description;
                accountPlan.Type = form.Type;

                await this.accountPlanRepository.UpdateAccountPlan(accountPlan);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public async Task<List<AccountPlanViewModel>> GetAllAccountPlans()
        {
            try
            {
                var response = await this.accountPlanRepository.GetAllAccountPlans();

                List<AccountPlanViewModel> accountPlans = new List<AccountPlanViewModel>();

                foreach (var item in response)
                {
                    accountPlans.Add(new AccountPlanViewModel()
                    {
                        Id = item.Id,
                        Description = item.Description,
                        Type = item.Type
                    });
                }

                return accountPlans;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAccountPlan(int id)
        {
            try
            {
                if(id == null)
                {
                    return false;
                }

                await this.accountPlanRepository.DeleteAccountPlan(id);
                
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}