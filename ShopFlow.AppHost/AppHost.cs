var builder = DistributedApplication.CreateBuilder(args);

//builder.AddProject<Projects.ShopFlow_Api>("shopflow-api");
// "Projects.ShopFlow_Api" is generated from the project reference (dots become underscores).
builder.AddProject<Projects.ShopFlow_Api>("api")
.WithHttpHealthCheck("/health");


builder.Build().Run();
