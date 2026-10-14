using ShopFlow.Catalog.Presentation;
var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults(); // OpenTelemetry, health checks, resilience, discovery
builder.Services.AddOpenApi();
var app = builder.Build();
app.MapDefaultEndpoints(); // /health and /alive (Development only, by template default)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // /openapi/v1.json
}
app.UseHttpsRedirection();
app.MapCatalogEndpoints();
app.Run();
