using AA.CommoditiesDashboard.Api.Controllers;
using AA.CommoditiesDashboard.Domain.Models;
using AA.CommoditiesDashboard.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Api.UnitTests.Controller
{
    public class CommodityControllerTests
    {
        private CommoditiesController _commodityController;
        private Mock<ICommodityProviderService> _commodityProviderService;

        [SetUp]
        public void Setup()
        {
            _commodityProviderService = new Mock<ICommodityProviderService>();
            _commodityController = new CommoditiesController(_commodityProviderService.Object);
        }
        [Test]
        public async Task When_GetRecentCommodityHistory_Is_Empty_Returns_Notfound()
        {
            //Arrange
            _commodityProviderService.Setup(x => x.GetRecentHistoryAsync(It.IsAny<int>())).ReturnsAsync((IEnumerable<CommodityRecentHistory>)null);

            //Act
            var response = await _commodityController.GetRecentCommodityHistory(5);
            var actual = (NotFoundResult)response;

            //Assert
            Assert.IsTrue(actual.StatusCode == StatusCodes.Status404NotFound);
        }

        [Test]
        public async Task Given_NoofDays_When_Request_GetRecentCommodityHistory_Expects_Ok()
        {
            //Arrange
            var expected = new[]
            {
                new CommodityRecentHistory(
                    "modelName",
                    "commodityName",
                    new []{new CommodityData(8.23M, -4, 3, 3.56M, DateTime.UtcNow)})
            };
            _commodityProviderService.Setup(x => x.GetRecentHistoryAsync(It.IsAny<int>()))
                .ReturnsAsync(expected);

            //Act
            var response = await _commodityController.GetRecentCommodityHistory(5);
            var actual = ((OkObjectResult)response).Value;

            //Assert
            Assert.AreEqual(actual,expected);
        }
    }
}
