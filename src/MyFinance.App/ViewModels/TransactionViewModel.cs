namespace MyFinance.App.ViewModels
{
    public class TransactionViewModel
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public string? Type { get; set; }

        public string? History { get; set; }

        public long AccountPlanId { get; set; }
        //public string? AccountPlanDescription { get; set; }

    }
}
