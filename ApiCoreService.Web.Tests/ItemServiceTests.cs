using InfraSkillsPro.Services;
using InfraSkillsPro.Models;
using Moq;
using Xunit;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace InfraSkillsPro.Tests
{
    public class ItemServiceTests
    {
        private readonly Mock<IMongoCollection<Item>> _mockCollection;
        private readonly Mock<IMongoDatabase> _mockDatabase;
        private readonly ItemService _itemService;

        public ItemServiceTests()
        {
            _mockCollection = new Mock<IMongoCollection<Item>>();
            _mockDatabase = new Mock<IMongoDatabase>();
            _mockDatabase.Setup(db => db.GetCollection<Item>(It.IsAny<string>(), It.IsAny<MongoCollectionSettings>())).Returns(_mockCollection.Object);
            _itemService = new ItemService(_mockDatabase.Object);
        }

        [Fact]
        public void GetAllItems_ReturnsListOfItems()
        {
            // Arrange
            var items = new List<Item>
                    {
                        new Item { Id = "1", Name = "Item1", Description = "Test Item 1" },
                        new Item { Id = "2", Name = "Item2", Description = "Test Item 2" }
                    }.AsQueryable();

            var mockCursor = new Mock<IAsyncCursor<Item>>();
            mockCursor.Setup(_ => _.Current).Returns(items);
            mockCursor.SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>())).Returns(true).Returns(false);

            _mockCollection.Setup(_ => _.FindSync(It.IsAny<FilterDefinition<Item>>(), It.IsAny<FindOptions<Item, Item>>(), It.IsAny<CancellationToken>())).Returns(mockCursor.Object);

            // Act
            var result = _itemService.GetAllItems();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Item1", result.First().Name);
        }
    }
}
