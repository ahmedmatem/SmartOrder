using MockQueryable;
using Moq;
using SmartOrder.Data.Models;
using SmartOrder.Data.Repository.Interfaces;
using SmartOrder.Services.Data;

namespace SmartOrder.Services.Tests
{
    [TestFixture]
    public class MenuCategoryServiceTests
    {
        private Mock<IRepository<MenuCategory, Guid>> menuCategoryRepoMock;
        private MenuCategoryService menuCategoryService;

        [SetUp]
        public void Setup()
        {
            menuCategoryRepoMock = new Mock<IRepository<MenuCategory, Guid>>();
            menuCategoryService = new MenuCategoryService(menuCategoryRepoMock.Object);
        }

        [Test]
        public async Task GetAllMenuCategoriesByVenueAsync_ShouldReturnCategories_WhenVenueExists()
        {
            var venueId = Guid.NewGuid();
            var categories = new List<MenuCategory>
            {
                new MenuCategory { Id = Guid.NewGuid(), Title = "Drinks", VenueId = venueId },
                new MenuCategory { Id = Guid.NewGuid(), Title = "Food", VenueId = venueId }
            };

            var mockDbSet = categories.AsQueryable().BuildMock();

            menuCategoryRepoMock.Setup(repo => repo.GetAllAttached()).Returns(mockDbSet);

            var result = await menuCategoryService.GetAllMenuCategoriesByVenueAsync(venueId);

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Title, Is.EqualTo("Drinks"));
        }

        [Test]
        public async Task GetAllMenuCategoriesByVenueAsync_ShouldReturnEmptyList_WhenNoCategoriesExist()
        {
            var venueId = Guid.NewGuid();
            var categories = new List<MenuCategory>();
            var mockDbSet = categories.AsQueryable().BuildMock();

            menuCategoryRepoMock.Setup(repo => repo.GetAllAttached()).Returns(mockDbSet);

            var result = await menuCategoryService.GetAllMenuCategoriesByVenueAsync(venueId);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task GetAllMenuCategoriesByVenueAsync_ShouldHandleNullVenueId()
        {
            var categories = new List<MenuCategory>
            {
                new MenuCategory { Id = Guid.NewGuid(), Title = "Drinks", VenueId = Guid.NewGuid() }
            };

            var mockDbSet = categories.AsQueryable().BuildMock();

            menuCategoryRepoMock.Setup(repo => repo.GetAllAttached()).Returns(mockDbSet);

            var result = await menuCategoryService.GetAllMenuCategoriesByVenueAsync(null);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task GetAllMenuCategoriesByVenueAsync_ShouldMapToViewModelCorrectly()
        {
            var venueId = Guid.NewGuid();
            var category = new MenuCategory { Id = Guid.NewGuid(), Title = "Desserts", VenueId = venueId };
            var categories = new List<MenuCategory> { category };
            var mockDbSet = categories.AsQueryable().BuildMock();

            menuCategoryRepoMock.Setup(repo => repo.GetAllAttached()).Returns(mockDbSet);

            var result = await menuCategoryService.GetAllMenuCategoriesByVenueAsync(venueId);

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Title, Is.EqualTo("Desserts"));
            Assert.That(result.First().Id, Is.EqualTo(category.Id.ToString()));
        }
    }
}
