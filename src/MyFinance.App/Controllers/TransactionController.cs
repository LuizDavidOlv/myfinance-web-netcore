using Microsoft.AspNetCore.Mvc;
using MyFinance.App.Services;
using MyFinance.App.ViewModels;

namespace MyFinance.App.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService transactionService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            this.transactionService = transactionService;
        }

        public async Task<IActionResult> Index()
        {
            List<TransactionViewModel> accountPlans = await this.transactionService.GetAllTransactions();

            //if (accountPlans.Count < 1)
            //{
            //    return RedirectToAction("CreateAccountPlan");
            //}

            ViewBag.List = accountPlans;

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

        //[HttpGet]
        //public IActionResult CreateTransaction(int? id)
        //{
        //    if (id != null)
        //    {
        //        TransactionModel transaction = new Transaction().GetTransactionById(id);
        //        ViewBag.Transaction = transaction;
        //    }

        //    ViewBag.AccountPlans = new AccountPlanModel().getAccountPlans();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateTransaction(TransactionModel form)
        //{
        //    Transaction transaction = new Transaction();

        //    if (form.Id == null)
        //    {
        //        transaction.Insert(form);
        //    }
        //    else
        //    {
        //        transaction.Update(form);
        //    }

        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult DeleteTransaction(int id)
        //{
        //    new Transaction().Delete(id);
        //    return RedirectToAction("Index");
        //}
    }
}
