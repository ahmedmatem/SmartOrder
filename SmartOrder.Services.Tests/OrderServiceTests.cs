using Moq;
using SmartOrder.Data.Models;
using SmartOrder.Data.Repository.Interfaces;
using SmartOrder.Services.Data;
using SmartOrder.Web.ViewModels.Order;
using SmartOrder.Web.ViewModels.OrderItem;
using SmartOrder.Common.Enums;
using MockQueryable;

namespace SmartOrder.Services.Tests
{
    [TestFixture]
    public class OrderServiceTests
    {
        private Mock<IRepository<Order, Guid>> orderRepoMock;
        private Mock<IRepository<OrderItem, Guid>> orderItemRepoMock;
        private OrderService orderService;

        [SetUp]
        public void Setup()
        {
            orderRepoMock = new Mock<IRepository<Order, Guid>>();
            orderItemRepoMock = new Mock<IRepository<OrderItem, Guid>>();
            orderService = new OrderService(orderRepoMock.Object, orderItemRepoMock.Object);
        }

        [Test]
        public async Task CreateOrderAsync_ShouldReturnTrue_WhenValidOrderIsCreated()
        {
            var viewModel = new OrderCreateViewModel
            {
                TableId = Guid.NewGuid().ToString(),
                Items = new List<OrderItemCreateViewModel>
                {
                    new OrderItemCreateViewModel { MenuItemId = Guid.NewGuid().ToString(), Quantity = 2 }
                }
            };

            var result = await orderService.CreateOrderAsync(viewModel);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task CreateOrderAsync_ShouldReturnFalse_WhenInvalidTableId()
        {
            var viewModel = new OrderCreateViewModel
            {
                TableId = "invalid-guid",
                Items = new List<OrderItemCreateViewModel>
                {
                    new OrderItemCreateViewModel { MenuItemId = Guid.NewGuid().ToString(), Quantity = 1 }
                }
            };

            var result = await orderService.CreateOrderAsync(viewModel);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetAllOrdersAsync_ShouldReturnOrders()
        {
            Table table = new Table() 
            {
                Id = Guid.NewGuid(),
                TableNumber = 5
            };

            var orders = new List<Order>
            {
                new Order { Id = Guid.NewGuid(), TableId = table.Id, Table = table, Status = OrderStatus.Pending }
            };
            var mockDbSet = orders.AsQueryable().BuildMock();

            orderRepoMock.Setup(repo => repo.GetAllAttached()).Returns(mockDbSet);

            var result = await orderService.GetAllOrdersAsync();

            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetOrderByIdAsync_ShouldReturnCorrectOrder()
        {
            Table table = new Table()
            {
                Id = Guid.NewGuid(),
                TableNumber = 5
            };

            var orderId = Guid.NewGuid();
            var order = new Order { Id = orderId, TableId = table.Id, Table = table, Status = OrderStatus.Pending };
            orderRepoMock.Setup(repo => repo.GetByIdAsync(orderId)).ReturnsAsync(order);

            var result = await orderService.GetOrderByIdAsync(orderId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(orderId.ToString()));
        }

        [Test]
        public async Task AssignOrderToWaiterAsync_ShouldSucceed_WhenOrderIsUnassigned()
        {
            var orderId = Guid.NewGuid();
            var waiterId = Guid.NewGuid();
            var order = new Order { Id = orderId, AssignedWaiterId = null };
            orderRepoMock.Setup(repo => repo.FirstOrDefaultAsync(o => o.Id == orderId)).ReturnsAsync(order);

            var result = await orderService.AssignOrderToWaiterAsync(orderId, waiterId);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task AssignOrderToWaiterAsync_ShouldFail_WhenOrderAlreadyAssigned()
        {
            var orderId = Guid.NewGuid();
            var waiterId = Guid.NewGuid();
            var order = new Order { Id = orderId, AssignedWaiterId = Guid.NewGuid() };
            orderRepoMock.Setup(repo => repo.FirstOrDefaultAsync(o => o.Id == orderId)).ReturnsAsync(order);

            var result = await orderService.AssignOrderToWaiterAsync(orderId, waiterId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task UpdateOrderStatusAsync_ShouldUpdateSuccessfully()
        {
            var orderId = Guid.NewGuid();
            var order = new Order { Id = orderId, Status = OrderStatus.Pending };
            orderRepoMock.Setup(repo => repo.GetByIdAsync(orderId)).ReturnsAsync(order);

            var result = await orderService.UpdateOrderStatusAsync(orderId, "Completed");

            Assert.That(result, Is.True);
            Assert.That(order.Status, Is.EqualTo(OrderStatus.Completed));
        }

        [Test]
        public async Task UpdateOrderStatusAsync_ShouldFail_WhenInvalidStatus()
        {
            var orderId = Guid.NewGuid();
            var order = new Order { Id = orderId, Status = OrderStatus.Pending };
            orderRepoMock.Setup(repo => repo.GetByIdAsync(orderId)).ReturnsAsync(order);

            var result = await orderService.UpdateOrderStatusAsync(orderId, "InvalidStatus");

            Assert.That(result, Is.False);
        }
    }
}
