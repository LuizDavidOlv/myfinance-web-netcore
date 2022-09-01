namespace MyFinance.App.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public double Value { get; set; }

        public string? Type { get; set; }

        public string? History { get; set; }

        public int AccountPlanId { get; set; }
        public string? AccountPlanDescription { get; set; }

    }
}
