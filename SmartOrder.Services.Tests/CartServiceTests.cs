using Microsoft.AspNetCore.Http;
using Moq;
using SmartOrder.Services.Data;
using SmartOrder.Web.ViewModels.Cart;
using System.Text;

namespace SmartOrder.Services.Tests
{
    [TestFixture]
    public class CartServiceTests
    {
        private Mock<IHttpContextAccessor> httpContextAccessorMock;
        private CartService cartService;
        private Mock<ISession> sessionMock;

        [SetUp]
        public void Setup()
        {
            httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            sessionMock = new Mock<ISession>();

            var context = new DefaultHttpContext();
            context.Session = new TestSession();

            httpContextAccessorMock.Setup(_ => _.HttpContext).Returns(context);
            cartService = new CartService(httpContextAccessorMock.Object);
        }

        [Test]
        public async Task AddToCartAsync_ShouldIncreaseQuantity_WhenItemAlreadyExists()
        {
            var cartItem = new CartItemViewModel { MenuItemId = "1", Quantity = 1 };
            await cartService.AddToCartAsync(cartItem);
            await cartService.AddToCartAsync(cartItem);
            var cart = await cartService.GetCartAsync();

            Assert.That(cart.Count, Is.EqualTo(1));
            Assert.That(cart[0].Quantity, Is.EqualTo(2));
        }

        [Test]
        public async Task RemoveFromCartAsync_ShouldRemoveItem_WhenItemExists()
        {
            var menuItemId = Guid.NewGuid().ToString();
            var cartItem = new CartItemViewModel { MenuItemId = menuItemId, Quantity = 1 };
            await cartService.AddToCartAsync(cartItem);
            await cartService.RemoveFromCartAsync(Guid.Parse(menuItemId));

            var cart = await cartService.GetCartAsync();

            Assert.That(cart.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task RemoveFromCartAsync_ShouldDoNothing_WhenItemDoesNotExist()
        {
            var menuItemId = Guid.NewGuid().ToString();
            var cartItem = new CartItemViewModel { MenuItemId = menuItemId, Quantity = 1 };
            await cartService.AddToCartAsync(cartItem);
            await cartService.RemoveFromCartAsync(Guid.NewGuid());
            var cart = await cartService.GetCartAsync();

            Assert.That(cart.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetCartAsync_ShouldReturnEmptyList_WhenCartIsEmpty()
        {
            var cart = await cartService.GetCartAsync();
            Assert.That(cart, Is.Empty);
        }

        [Test]
        public async Task ClearCartAsync_ShouldEmptyCart_AfterAddingItems()
        {
            var cartItem1 = new CartItemViewModel { MenuItemId = "1", Quantity = 1 };
            var cartItem2 = new CartItemViewModel { MenuItemId = "2", Quantity = 1 };
            await cartService.AddToCartAsync(cartItem1);
            await cartService.AddToCartAsync(cartItem2);

            await cartService.ClearCartAsync();
            var cart = await cartService.GetCartAsync();

            Assert.That(cart.Count, Is.EqualTo(0));
        }
    }

    public class TestSession : ISession
    {
        private Dictionary<string, byte[]> _sessionStorage = new Dictionary<string, byte[]>();

        public bool TryGetValue(string key, out byte[] value) => _sessionStorage.TryGetValue(key, out value);

        public void Set(string key, byte[] value) => _sessionStorage[key] = value;

        public void Remove(string key) => _sessionStorage.Remove(key);
        public void Clear() => _sessionStorage.Clear();
        public IEnumerable<string> Keys => _sessionStorage.Keys;

        public void SetString(string key, string value) => Set(key, Encoding.UTF8.GetBytes(value));

        public string GetString(string key) => _sessionStorage.ContainsKey(key) ? Encoding.UTF8.GetString(_sessionStorage[key]) : null;

        public Task LoadAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        public Task CommitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        public bool IsAvailable => true;
        public string Id => "TestSession";
    }
}