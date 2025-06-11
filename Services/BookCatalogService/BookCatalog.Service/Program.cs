using BookCatalog.Service.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddHttpClient<OpenLibraryClient>();

builder.Services.AddControllers();

WebApplication app = builder.Build();

app.MapControllers();

await app.RunAsync();

public partial class Program { } // for integration tests
