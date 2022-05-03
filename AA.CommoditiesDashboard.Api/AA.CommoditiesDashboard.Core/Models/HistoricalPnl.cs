namespace AA.CommoditiesDashboard.Domain.Models
{
    public class HistoricalPnl
    {
        public HistoricalPnl(string date, decimal pnlSum, string commodity)
        {
            Date = date;
            PnlSum = pnlSum;
            Commodity = commodity;
        }

        public string Date { get; }
        public decimal PnlSum { get; set; }
        public string Commodity { get; }
    }
}
