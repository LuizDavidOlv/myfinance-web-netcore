using Microsoft.AspNetCore.Mvc;
using MyFinance.App.Services;
using MyFinance.App.ViewModels;
using MyFinance.Business.Models;

namespace MyFinance.App.Controllers
{
    public class AccountPlanController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IAccountPlanService accountPlanService;

        public AccountPlanController(ILogger<HomeController> logger, IAccountPlanService accountPlanService)
        {
            _logger = logger;
            this.accountPlanService = accountPlanService;
        }


        public async Task<IActionResult> Index()
        {
            List<AccountPlanViewModel> accountPlans = await this.accountPlanService.GetAllAccountPlans();

            if (accountPlans.Count < 1)
            {
                return RedirectToAction("CreateAccountPlan");
            }

            ViewBag.List = accountPlans;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAccountPlan(int id)
        {
            //remover esse endpoint intermediário
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccountPlan(AccountPlanViewModel form)
        {
            await this.accountPlanService.CreateAccountPlan(form);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAccountPlan(int id)
        {
            //remover esse endpoint intermediário
            return View();
        }

        [HttpPost]//Mudar verbo
        public async Task<IActionResult> UpdateAccountPlan(AccountPlanViewModel form)
        {

            await this.accountPlanService.UpdateAccountPlan(form);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> DeleteAccountPlan(long id)
        {
            await this.accountPlanService.DeleteAccountPlan(id);
            return RedirectToAction("Index");

        }
    }
}

