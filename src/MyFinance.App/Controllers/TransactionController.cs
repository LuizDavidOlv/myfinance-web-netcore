using Microsoft.AspNetCore.Mvc;
using MyFinance.App.Services;
using MyFinance.App.ViewModels;
using MyFinance.Business.Models;

namespace MyFinance.App.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService transactionService;
        private readonly IAccountPlanService accountPlanService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService, IAccountPlanService accountPlanService)
        {
            _logger = logger;
            this.transactionService = transactionService;
            this.accountPlanService = accountPlanService;
        }

        public async Task<IActionResult> Index()
        {
            //return RedirectToAction("CreateTransaction");
            List<TransactionViewModel> TransactionPlans = await this.transactionService.GetAllTransactions();

            //if (accountPlans.Count < 1)
            //{
            //    return RedirectToAction("CreateTransaction");
            //}

            ViewBag.List = TransactionPlans;

            return View();
        }

        //[HttpGet]
        //public IActionResult TransactionsReport()
        //{
        //    TransactionsReportModel model = new TransactionsReportModel();
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult TransactionsReport(TransactionsReportModel model)
        //{
        //    if (model.StartDate != null || model.EndDate != null)
        //    {
        //        model.Transactions = new Transaction().filterTransactions(model.StartDate, model.EndDate);
        //    }

        //    return View(model);
        //}

        [HttpGet]
        public async Task<IActionResult> UpdateTransaction(int id)
        {
            List<AccountPlanViewModel> accountPlan = await this.accountPlanService.GetAllAccountPlans();
            ViewBag.AccountPlans = accountPlan;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTransaction(TransactionViewModel form)
        {
            await this.transactionService.UpdateTransaction(form);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateTransaction(int? id)
        {
            List<AccountPlanViewModel> accountPlans = await this.accountPlanService.GetAllAccountPlans();
            ViewBag.AccountPlans = accountPlans;
            
            return View();
        }

        [HttpPost]
        public IActionResult CreateTransaction(TransactionViewModel form)
        {
            this.transactionService.CreateTransaction(form);

            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult DeleteTransaction(int id)
        //{
        //    new Transaction().Delete(id);
        //    return RedirectToAction("Index");
        //}
    }
}
