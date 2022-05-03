using System.Collections.Generic;

namespace AA.CommoditiesDashboard.Domain.Models
{
    public class CommodityPrice
    {
        public CommodityPrice(string commodity,  string date, decimal price)
        {
            Commodity = commodity;
            Price = price;
            Date = date;
        }
        public string Date { get; }
        public decimal Price { get;}
        public string Commodity { get; }
    }

}
