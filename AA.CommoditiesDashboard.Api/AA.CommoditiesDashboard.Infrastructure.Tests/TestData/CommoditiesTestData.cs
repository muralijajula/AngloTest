using AA.CommoditiesDashboard.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AA.CommoditiesDashboard.Infrastructure.Tests.TestData
{
    public static class CommoditiesTestData
    {
        public static IQueryable<CommodityData> CommoditiesData()
        {
            return new List<CommodityData>{
                new CommodityData{
                    Id = 1,
                    CommodityId = 1,
                    Commodity = new Commodity{
                        Id = 1,
                        Name = "Commodity",
                        Model = new Model{Id=1,Name="Model"
                        } },
                    Position = -4,
                    NewTradeAction = 3,
                    Price=8.23M,
                    PnlDaily=3.56M,
                    Date=DateTime.Now
                   },
                new CommodityData{
                    Id = 2,
                    CommodityId = 2,
                    Commodity = new Commodity{
                        Id = 2,
                        Name = "Commodity2",
                        Model = new Model{Id=2,Name="Model2"
                        } },
                    Position = -4,
                    NewTradeAction = 3,
                    Price=8.23M,
                    PnlDaily=2.44M,
                    Date=DateTime.Now.AddDays(-10)
                   }                 
            }.AsQueryable();
        }

    }
}
