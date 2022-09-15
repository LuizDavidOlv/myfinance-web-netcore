namespace MyFinance.App.ViewModels
{
    public class TransactionReportViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<TransactionViewModel> Transactions { get; set; }

        public TransactionReportViewModel()
        {
            Transactions = new List<TransactionViewModel>();
        }
    }
}
