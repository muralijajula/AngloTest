using AA.CommoditiesDashboard.Domain.Service;
using AA.CommoditiesDashboard.Infrastructure.Entities;
using AA.CommoditiesDashboard.Infrastructure.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Domain.Tests.Services
{
    public class HistoricalTrendsServiceTests
    {
        private Mock<ICommodityDataRepository> _commodityDataRepository;
        private HistoricalTrendsService _historicalTrendsService;

        [SetUp]
        public void Setup()
        {
            _commodityDataRepository = new Mock<ICommodityDataRepository>();
            _historicalTrendsService = new HistoricalTrendsService(_commodityDataRepository.Object);
        }

        [Test]
        public async Task When_Request_GetHistoricalPnLAsync_Returns_Historical_Pnl()
        {
            //Arrange
            List<CommodityData> expected = GetCommodityData();
            _commodityDataRepository.Setup(x => x.GetRecentCommodityHistory(It.IsAny<int?>())).ReturnsAsync(expected);


            //Act
            var response = await _historicalTrendsService.GetHistoricalPnLAsync(Models.MetricType.Yearly);

            //Assert
            Models.HistoricalPnl actualHistory = response.FirstOrDefault();
            Assert.AreEqual(actualHistory.PnlSum, expected.Sum(x => x.PnlDaily));
            Assert.AreEqual(actualHistory.Commodity, expected[0].Commodity.Name);

            
        }

        [Test]
        public async Task When_Request_GetHistoricalPnLByCommodityAsync_Returns_Historical_Pnl()
        {
            //Arrange
            var expected = GetCommodityData();
            _commodityDataRepository.Setup(x => x.GetRecentCommodityHistory(It.IsAny<int?>())).ReturnsAsync(expected);


            //Act
            var response = await _historicalTrendsService.GetHistoricalPnLByCommodityAsync("Commodity",DateTime.UtcNow.Year.ToString());

            //Assert
            Models.HistoricalPnl actualHistory = response.FirstOrDefault();
            Models.HistoricalPnl actualSecondHistory = response.LastOrDefault();

            Assert.AreEqual(actualHistory.PnlSum, expected[0].PnlDaily);
            Assert.AreEqual(actualSecondHistory.PnlSum, expected[1].PnlDaily);
            Assert.AreEqual(actualHistory.Commodity, expected[0].Commodity.Name);
        }

        private List<CommodityData> GetCommodityData()
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
                    CommodityId = 1,
                    Commodity = new Commodity{
                        Id = 1,
                        Name = "Commodity",
                        Model = new Model{Id=1,Name="Model"
                        } },
                    Position = -4,
                    NewTradeAction = 3,
                    Price=8.23M,
                    PnlDaily=2.44M,
                    Date=DateTime.Now.AddDays(-1)
                   }
            };
        }

    }
}
