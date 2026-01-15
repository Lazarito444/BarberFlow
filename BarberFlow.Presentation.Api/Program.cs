using BarberFlow.Infrastructure.Data.Extensions;
using BarberFlow.Presentation.Api.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));

builder.Services.SetupOpenApi();
builder.Services.AddDataLayer(connectionString);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseScalar();
}

app.UseHttpsRedirection();

app.Run();
