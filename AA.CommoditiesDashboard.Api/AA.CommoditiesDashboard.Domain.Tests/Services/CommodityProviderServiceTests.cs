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
    public class CommodityProviderServiceTests
    {
        private Mock<ICommodityDataRepository> _commodityDataRepository;
        private CommodityProviderService commodityProviderService;

        [SetUp]
        public void Setup()
        {
            _commodityDataRepository = new Mock<ICommodityDataRepository>();
            commodityProviderService = new CommodityProviderService(_commodityDataRepository.Object);
        }

        [Test]
        public async Task When_Request_GetRecentHistoryAsync_Returns_Recent_Transactions()
        {
            //Arrange
            var expected = new List<CommodityData>{
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
                   }
            };
            _commodityDataRepository.Setup(x => x.GetRecentCommodityHistory(5)).ReturnsAsync(expected);
           

            //Act
            var response = await commodityProviderService.GetRecentHistoryAsync(5);

            //Assert
            Models.CommodityRecentHistory actualHistory = response.FirstOrDefault();
            Assert.AreEqual(actualHistory.Model, expected[0].Commodity.Model.Name);
            Assert.AreEqual(actualHistory.Commodity, expected[0].Commodity.Name);
            Assert.AreEqual(actualHistory.DataPoints.FirstOrDefault().Price, expected[0].Price);
            Assert.AreEqual(actualHistory.DataPoints.FirstOrDefault().PnlDaily, expected[0].PnlDaily);
        }
    }
}
