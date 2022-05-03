namespace AA.CommoditiesDashboard.Domain.Models
{
    public class ModelPnl
    {
        public ModelPnl(string model, string date, decimal pnl)
        {
            Model = model;
            Pnl = pnl;
            Date = date;
        }
        public string Date { get; }
        public decimal Pnl { get; }
        public string Model { get; }
    }

}
