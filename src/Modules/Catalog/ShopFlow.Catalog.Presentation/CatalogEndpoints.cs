using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using ShopFlow.Catalog.Application.Products;
using ShopFlow.Catalog.Domain.Products;
namespace ShopFlow.Catalog.Presentation;

public static class CatalogEndpoints
{
    public static IEndpointRouteBuilder MapCatalogEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/catalog/products").WithTags("Catalog");
        group.MapGet("/", () => TypedResults.Ok(SampleProducts.All));
        // An explicit return type documents BOTH possible responses for OpenAPI.
        group.MapGet("/{id:guid}", Results<Ok<ProductResponse>, NotFound> (Guid id) =>
        {
            var product = SampleProducts.All.FirstOrDefault(p => p.Id == id);
            return product is null ? TypedResults.NotFound() : TypedResults.Ok(product);
        });
        return app;
    }
}
// TEMPORARY: replaced by a real use case + database in Weeks 5-6.
internal static class SampleProducts
{
    public static readonly IReadOnlyList<ProductResponse> All =
    [
    ToResponse(Product.Create("Mechanical Keyboard", "kb-001", 4999m)),
    ToResponse(Product.Create("Wireless Mouse", "ms-002", 1499m)),
    ToResponse(Product.Create("27in 4K Monitor", "mn-003", 28999m)),
    ];
    private static ProductResponse ToResponse(Product p) => new(p.Id, p.Name, p.Sku, p.Price);
}
