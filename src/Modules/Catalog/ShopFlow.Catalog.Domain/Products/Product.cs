using ShopFlow.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ShopFlow.Catalog.Domain.Products
{
    public sealed class Product : Entity<Guid>
    {
        private Product(Guid id, string name, string sku, decimal price) : base(id)
        {
            Name = name;
            Sku = sku;
            Price = price;
        }
        public string Name { get; private set; }
        public string Sku { get; private set; }
        public decimal Price { get; private set; }

        // Factory method: the only way to create a Product, so it is always valid.
        public static Product Create(string name, string sku, decimal price)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(sku);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            // Version 7 GUIDs are time-ordered, which is friendlier to database indexes than random v4.
            return new Product(Guid.CreateVersion7(), name.Trim(), sku.Trim().ToUpperInvariant(),
            price);
        }
        public void ChangePrice(decimal newPrice)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(newPrice);
            Price = newPrice;
        }

    }
}
