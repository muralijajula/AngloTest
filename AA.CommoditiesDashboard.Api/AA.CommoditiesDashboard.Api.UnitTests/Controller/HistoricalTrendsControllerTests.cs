using AA.CommoditiesDashboard.Api.Controllers;
using AA.CommoditiesDashboard.Domain.Models;
using AA.CommoditiesDashboard.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Api.UnitTests.Controller
{
    public class HistoricalTrendsControllerTests
    {
        private HistoricalTrendsController _historicalTrendsController;
        private Mock<IHistoricalTrendsService> _historicalTrendsService;

        [SetUp]
        public void Setup()
        {
            _historicalTrendsService = new Mock<IHistoricalTrendsService>();
            _historicalTrendsController = new HistoricalTrendsController(_historicalTrendsService.Object);
        }

        [Test]
        public async Task When_Request_GetHistoricalPnL_With_NoParam_Expects_Default_Yearly_Metric_Results()
        {
            //Arrange
            var expected = new[]
            {
                new HistoricalPnl(
                    DateTime.UtcNow.ToString("MMM yy"),120.02M,"Commodity")
            };
            _historicalTrendsService.Setup(x => x.GetHistoricalPnLAsync(MetricType.Yearly))
                .ReturnsAsync(expected);

            //Act
            var response = await _historicalTrendsController.GetHistoricalPnL();

            //Assert
            _historicalTrendsService.Verify(x=>x.GetHistoricalPnLAsync(MetricType.Yearly), Times.Once);

        }

        [Test]
        public async Task When_Request_GetHistoricalPnL_With_NoParam_Returns_OkResult()
        {
            //Arrange
            var expected = new[]
            {
                new HistoricalPnl(
                    DateTime.UtcNow.ToString("MMM yy"),120.02M,"Commodity")
            };
            _historicalTrendsService.Setup(x => x.GetHistoricalPnLAsync(It.IsAny<MetricType>()))
                .ReturnsAsync(expected);

            //Act
            var response = await _historicalTrendsController.GetHistoricalPnL();
            var actual = ((OkObjectResult)response).Value;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public async Task When_Request_GetHistoricalPnL_With_Param_Returns_OkResult()
        {
            //Arrange
            var expected = new[]
            {
                new HistoricalPnl(
                    DateTime.UtcNow.ToString("MM-dd-yy"),10.02M,"Commodity")
            };
            _historicalTrendsService.Setup(x => x.GetHistoricalPnLByCommodityAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(expected);

            //Act
            var response = await _historicalTrendsController.GetHistoricalPnL("Commodity","date");
            var actual = ((OkObjectResult)response).Value;

            //Assert
            _historicalTrendsService.Verify(x => x.GetHistoricalPnLByCommodityAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.AreEqual(actual, expected);
        }


    }
}
