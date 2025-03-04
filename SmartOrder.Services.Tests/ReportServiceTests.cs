using Moq;
using SmartOrder.Data.Models;
using SmartOrder.Data.Repository.Interfaces;
using SmartOrder.Services.Data;
using MockQueryable;

namespace SmartOrder.Services.Tests
{
    [TestFixture]
    public class ReportServiceTests
    {
        private Mock<IRepository<Order, Guid>> orderRepoMock;
        private ReportService reportService;

        [SetUp]
        public void Setup()
        {
            orderRepoMock = new Mock<IRepository<Order, Guid>>();
            reportService = new ReportService(orderRepoMock.Object);
        }

        [Test]
        public async Task GetSalesReportAsync_ShouldReturnCorrectData()
        {
            var venueId = Guid.NewGuid().ToString();
            var orders = new List<Order>
            {
                new Order { Table = new Table { VenueId = Guid.Parse(venueId), TableNumber = 1 }},
                new Order { Table = new Table { VenueId = Guid.Parse(venueId), TableNumber = 2 }}
            };

            var mockDbSet = orders.AsQueryable().BuildMock();

            orderRepoMock.Setup(repo => repo.GetAllAttached()).Returns(mockDbSet);

            var result = await reportService.GetSalesReportAsync(venueId);

            Assert.That(result.Count(), Is.EqualTo(2));
        }
    }
}
