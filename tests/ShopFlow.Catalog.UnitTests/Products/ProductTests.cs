using ShopFlow.Catalog.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopFlow.Catalog.UnitTests.Products
{
    public class ProductTests
    {
        [Fact]
        public void Create_WithValidInput_TrimsNameAndNormalisesSku()
        {
            var product = Product.Create(" Keyboard ", " kb-001 ", 4999m);
            Assert.Equal("Keyboard", product.Name);
            Assert.Equal("KB-001", product.Sku);
            Assert.NotEqual(Guid.Empty, product.Id);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_WithNonPositivePrice_Throws(int price)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Product.Create("Keyboard", "kb-001",
            price));
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Create_WithBlankName_Throws(string name)
        {
            Assert.Throws<ArgumentException>(() => Product.Create(name, "kb-001", 100m));
        }
        [Fact]
        public void ChangePrice_UpdatesPrice()
        {
            var product = Product.Create("Keyboard", "kb-001", 100m);
            product.ChangePrice(150m);
            Assert.Equal(150m, product.Price);
        }

    }
}
