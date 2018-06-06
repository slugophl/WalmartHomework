using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WalmartHomework.Controllers;
using WalmartHomework.Core.Interfaces;
using WalmartHomework.Core.Models;
using Xunit;

namespace WalmartHomework.Tests
{
    public class ProductsControllerTests
    {
        private readonly Mock<ILogger<ProductsController>> _mockLogger;

        public ProductsControllerTests()
        {
            _mockLogger = new Mock<ILogger<ProductsController>>();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Search_Valid_Valid_Query_Return_Ok()
        {
            var mockWalmartOpenApiClient = new Mock<IWalmartOpenApiClient>();
            mockWalmartOpenApiClient.Setup(x => x.Search(It.IsAny<string>())).Returns(Task.FromResult(new SearchResponse
            {
                Query = "ipod",
                Sort = "relevance",
                ResponseGroup = "base",
                TotalResults = 409,
                Start = 1,
                NumItems = 10,
                Items = new List<ItemResponse>
                {
                    new ItemResponse { ItemId = 42608125, ParentItemId = 42608125, Name = "Apple iPod touch 32GB", Msrp = 247, SalePrice = 189, Upc = "888462353151", CategoryPath = "Electronics/Portable Audio/Apple iPods/iPod Touch" }
                }
            }));

            var controller = new ProductsController(mockWalmartOpenApiClient.Object, _mockLogger.Object);

            var response = await controller.Search("ipod");

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Search_Empty_Query_Return_BadRequest()
        {
            var mockWalmartOpenApiClient = new Mock<IWalmartOpenApiClient>();
            mockWalmartOpenApiClient.Setup(x => x.Search(It.IsAny<string>())).Returns(Task.FromResult(new SearchResponse()));

            var controller = new ProductsController(mockWalmartOpenApiClient.Object, _mockLogger.Object);

            var response = await controller.Search("");

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Lookup_Product_Valid_Id_Return_Ok()
        {
            var mockWalmartOpenApiClient = new Mock<IWalmartOpenApiClient>();
            mockWalmartOpenApiClient.Setup(x => x.LookupProduct(It.IsAny<long>())).Returns(Task.FromResult(new ItemResponse
            {
                ItemId = 12417832,
                ParentItemId = 12417832,
                Name = "MLB - Clear Acrylic Baseball Case",
                SalePrice = 12.95,
                CategoryPath = "Sports & Outdoors/Sports Fan Shop/Sports & Outdoor Play Fan Shop/Sports Equipment Fan Shop",
                ShortDescription = "short description is not available",
                LongDescription = "&quot;The deluxe ball cube is perfect for a collectible baseball. It is made of 1/8th inch thick acrylic and has a black acrylic base with a small clear acrylic removable lid. Measures: 5&quot;&quot; x 4 1/4 &quot;&quot; x 4.&quot;&quot; Memorabilia sold separately. Please Note:This item has handling time. If an upgraded shipping method is chosen, the handling time shown will still apply.&quot;"
            }));

            var controller = new ProductsController(mockWalmartOpenApiClient.Object, _mockLogger.Object);

            var response = await controller.LookupProduct(12417832);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Lookup_Product_Invalid_Id_Return_BadRequest()
        {
            var mockWalmartOpenApiClient = new Mock<IWalmartOpenApiClient>();
            mockWalmartOpenApiClient.Setup(x => x.LookupProduct(It.IsAny<long>())).Returns(Task.FromResult(new ItemResponse
            {
                ItemId = 0,
                ParentItemId = 0,
                Name = null,
                SalePrice = 0,
                Upc = null,
                CategoryPath = null
            }));

            var controller = new ProductsController(mockWalmartOpenApiClient.Object, _mockLogger.Object);

            var response = await controller.LookupProduct(98765432123456789);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task Get_Recommendations_Valid_Id_Return_Ok()
        {
            var mockWalmartOpenApiClient = new Mock<IWalmartOpenApiClient>();
            mockWalmartOpenApiClient.Setup(x => x.GetRecommendations(It.IsAny<long>())).Returns(Task.FromResult(new RecommendationsResponse
            {
                Recommendations = new List<ItemResponse>
                {
                    new ItemResponse
                    {
                        ItemId = 44569327,
                        ParentItemId = 44569327,
                        Name = "ONN Skin for Apple iPod touch",
                        SalePrice = 7.88,
                        Upc = "681131073608",
                        CategoryPath = "Cell Phones/Accessories/Cases & Protectors/Cell Phone Cases",
                        ShortDescription = "Protect your device in style with the ONN Skin for Apple iPod touch.",
                        LongDescription = "&lt;br&gt;&lt;b&gt;ONN Skin for Apple iPod touch:&lt;/b&gt;&lt;ul&gt;&lt;li&gt;Complete access to multi-touch display, controls and connectors to protect device and keep full functionality&lt;/li&gt;&lt;li&gt;"
                    },
                    new ItemResponse
                    {
                        ItemId = 22733613,
                        ParentItemId = 22733613,
                        Name = "OtterBox iPod Touch 5G Case Defender Series, Coal",
                        Msrp = 25.12,
                        SalePrice = 21.97,
                        Upc = "660543017929",
                        CategoryPath = "Electronics/Portable Audio/MP3 Accessories/Cases, Skins & Armbands",
                        ShortDescription = "The OtterBox Defender Series iPod touch 5G case is made for adventure.",
                        LongDescription = "&lt;br&gt;&lt;b&gt;OtterBox iPod Touch 5G Case Defender Series:&lt;/b&gt;&lt;ul&gt;&lt;li&gt;Silicone plugs cover main openings&lt;/li&gt;&lt;li&gt;"
                    }
                }
            }));

            var controller = new ProductsController(mockWalmartOpenApiClient.Object, _mockLogger.Object);

            var response = await controller.GetRecommendations(42608125);

            Assert.IsType<OkObjectResult>(response);
        }
    }
}
