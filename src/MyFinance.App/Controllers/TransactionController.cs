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
            ViewBag.CreditoTemp = "0";
            ViewBag.DebitoTemp = "0";
            //return RedirectToAction("CreateTransaction");
            List<TransactionViewModel> TransactionPlans = await this.transactionService.GetAllTransactions();

            //if (accountPlans.Count < 1)
            //{
            //    return RedirectToAction("CreateTransaction");
            //}

            ViewBag.List = TransactionPlans;

            return View();
        }

        [HttpGet]
        public IActionResult TransactionsReport()
        {
            TransactionReportViewModel model = new TransactionReportViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> TransactionsReport(TransactionReportModel model)
        {
            TransactionReportViewModel transacoes = new TransactionReportViewModel();
            if (model.StartDate != null || model.EndDate != null)
            {
                transacoes = await this.transactionService.GetTransactionsByDate(model);
                int credito = this.transactionService.CountCredit(transacoes);
                int debito = this.transactionService.CountDebit(transacoes);
                ViewBag.CreditoTemp = credito.ToString();
                ViewBag.DebitoTemp = debito.ToString();
            }

            return View(transacoes);
        }

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
        public async Task<IActionResult> CreateTransaction(TransactionViewModel form)
        {
            await this.transactionService.CreateTransaction(form);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTransaction(long id)
        {
            await this.transactionService.DeleteTransaction(id);

            return RedirectToAction("Index");
        }

       
    }
}
