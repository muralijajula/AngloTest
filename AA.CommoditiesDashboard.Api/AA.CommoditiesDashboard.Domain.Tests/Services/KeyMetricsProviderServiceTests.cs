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
    public class KeyMetricsProviderServiceTests
    {
        private Mock<ICommodityDataRepository> _commodityDataRepository;
        private KeyMetricsProviderService _keyMetricsProviderService;

        [SetUp]
        public void Setup()
        {
            _commodityDataRepository = new Mock<ICommodityDataRepository>();
            _keyMetricsProviderService = new KeyMetricsProviderService(_commodityDataRepository.Object);
        }

        [Test]
        public async Task When_Request_GetKeyMetricPnlByCommodityAsync_Returns_Historical_Pnl()
        {
            //Arrange
            List<CommodityData> expected = GetCommodityData();
            _commodityDataRepository.Setup(x => x.GetRecentCommodityHistory(It.IsAny<int?>())).ReturnsAsync(expected);


            //Act
            var response = await _keyMetricsProviderService.GetKeyMetricPnlByCommodityAsync(Models.MetricType.Monthly);

            //Assert
            Models.CommodityPrice actualHistory = response.FirstOrDefault();
            Assert.AreEqual(actualHistory.Price, expected.Average(x => x.Price));
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
