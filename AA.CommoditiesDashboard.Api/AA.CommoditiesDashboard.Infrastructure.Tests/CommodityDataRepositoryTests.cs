using AA.CommoditiesDashboard.Infrastructure.Data.Contexts;
using AA.CommoditiesDashboard.Infrastructure.Repositories;
using AA.CommoditiesDashboard.Infrastructure.Tests.TestData;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Infrastructure.Tests
{
    public class CommodityDataRepositoryTests
    {
        private CommoditiesDashboardDbContext _dbContext;
        private CommodityDataRepository _commodityDataRepository;

        [SetUp]
        public void Setup()
        {
            _dbContext = InMemoryDbContextFactory.GetCommoditiesDashboardDbContext();
            _dbContext.CommoditiesData.AddRange(CommoditiesTestData.CommoditiesData());
            _dbContext.SaveChanges();
            _commodityDataRepository = new CommodityDataRepository(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }


        [Test]
        public async Task Should_Get_Recent_Commodity_History()
        {
            var history = await _commodityDataRepository.GetRecentCommodityHistory(5);
            Assert.AreEqual(history.Count(), 1);
        }

        [Test]
        public async Task Should_Get_All_Commodity_History()
        {
            var history = await _commodityDataRepository.GetRecentCommodityHistory();
            Assert.AreEqual(history.Count(), 2);
        }
    }
}
