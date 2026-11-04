using DemoFullstack.Application.Features.Tickets.CreateTicket;
using DemoFullstack.Application.Features.Tickets.GetTicket;
using DemoFullstack.Application.Interface;
using DemoFullstack.Infrastructure.Persistence;
using DemoFullstack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' was not configured.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<CreateTicketUseCase>();
builder.Services.AddScoped<GetTicketsUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

if (app.Environment.IsDevelopment())
{
    await using var scope = app.Services.CreateAsyncScope();

    var context = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    await DbSeeder.SeedAsync(context);
}

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "DemoFullstack API v1"
        );
    });
}

// Serve index.html e os arquivos compilados do React.
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

// Rotas inexistentes da API continuam retornando 404.
app.MapFallback("/api/{**path}", () => Results.NotFound());

// Permite abrir diretamente rotas do frontend.
app.MapFallbackToFile("index.html");

app.Run();
