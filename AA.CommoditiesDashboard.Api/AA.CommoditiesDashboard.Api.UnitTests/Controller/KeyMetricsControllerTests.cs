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
    public class KeyMetricsControllerTests
    {
        private KeyMetricsController _keyMetricsController;
        private Mock<IKeyMetricsProviderService> _keyMetricsService;

        [SetUp]
        public void Setup()
        {
            _keyMetricsService = new Mock<IKeyMetricsProviderService>();
            _keyMetricsController = new KeyMetricsController(_keyMetricsService.Object);
        }

        [Test]
        public async Task When_Request_keyMetricsController_With_NoParam_Expects_Default_Monthly_Metric_Results()
        {
            //Arrange
            var expected = new[]
            {
                new CommodityPrice(
                    "Commodity",DateTime.UtcNow.ToString("MMM yy"),120.02M)
            };
            _keyMetricsService.Setup(x => x.GetKeyMetricPnlByCommodityAsync(MetricType.Monthly))
                .ReturnsAsync(expected);

            //Act
            var response = await _keyMetricsController.GetKeyMetricPriceByCommodity();

            //Assert
            _keyMetricsService.Verify(x => x.GetKeyMetricPnlByCommodityAsync(MetricType.Monthly), Times.Once);

        }

        [Test]
        public async Task When_Request_GetHistoricalPnL_With_NoParam_Returns_OkResult()
        {
            //Arrange
            var expected = new[]
            {
                new CommodityPrice(
                    "Commodity",DateTime.UtcNow.ToString("MMM yy"),120.02M)
            };
            _keyMetricsService.Setup(x => x.GetKeyMetricPnlByCommodityAsync(MetricType.Monthly))
                .ReturnsAsync(expected);

            //Act
            //Act
            var response = await _keyMetricsController.GetKeyMetricPriceByCommodity();
            var actual = ((OkObjectResult)response).Value;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public async Task When_Request_GetKeyMetricPnlByModel_With_No_Param_Returns_OkResult()
        {
            //Arrange
            var expected = new[]
            {
                new ModelPnl(
                    "Model",DateTime.UtcNow.ToString("MM-dd-yy"),10.02M)
            };
            _keyMetricsService.Setup(x => x.GetKeyMetricPnlByModelAsync(It.IsAny<MetricType>()))
                .ReturnsAsync(expected);

            //Act
            var response = await _keyMetricsController.GetKeyMetricPnlByModel();

            var actual = ((OkObjectResult)response).Value;

            //Assert
            _keyMetricsService.Verify(x => x.GetKeyMetricPnlByModelAsync(It.IsAny<MetricType>()), Times.Once);
            Assert.AreEqual(actual, expected);
        }

    }
}
