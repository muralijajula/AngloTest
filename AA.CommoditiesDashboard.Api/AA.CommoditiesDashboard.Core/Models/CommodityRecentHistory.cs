using System.Collections.Generic;

namespace AA.CommoditiesDashboard.Domain.Models
{
    public class CommodityRecentHistory
    {
        public string Model { get; }
        public string Commodity { get; }
        public IEnumerable<CommodityData> DataPoints { get; }

        public CommodityRecentHistory(
            string commodity,
            string model,
            IEnumerable<CommodityData> dataPoints)
        {
            Model = model;
            Commodity = commodity;
            DataPoints = dataPoints;
        }
    }
}
