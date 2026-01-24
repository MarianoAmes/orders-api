using Microsoft.EntityFrameworkCore;
using OrderTechnicalTest.Application.Internal;
using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Domain.Repositories;
using OrderTechnicalTest.Domain.Services;
using OrderTechnicalTest.Infrastructure.EFC.Context;
using OrderTechnicalTest.Infrastructure.EFC.Repositories;
using OrderTechnicalTest.Infrastructure.EFC.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AppDbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

// Repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ApplicationServices
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    // BD / tablas
    context.Database.EnsureCreated();

    // Seed
    var productCommandService = services.GetRequiredService<IProductCommandService>();
    Console.WriteLine("🌱 Seeding products...");
    await productCommandService.Handle(new SeedProductsCommand());
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();