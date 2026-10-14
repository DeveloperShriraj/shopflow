using System;
using System.Collections.Generic;
using System.Text;

namespace ShopFlow.Catalog.Application.Products
{
    // A record gives value equality and immutability: ideal for DTOs.
    public sealed record ProductResponse(Guid Id, string Name, string Sku, decimal Price);

    //public class ProductResponse
    //{

    //}
}
