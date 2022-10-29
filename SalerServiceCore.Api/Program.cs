using Microsoft.Extensions.Diagnostics.HealthChecks;
using SalerServiceCore.Domain.Model;
using SalerServiceCore.Domain.SellerAggregate;
using SalerServiceCore.Domain.SellerAggregate.Abstractions;
using SalerServiceCore.Infrastructure.SellersRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddCheck("Default", () => HealthCheckResult.Healthy("Ok"))
    //add more check here
    ;
// AddSingleton des que je lance mon application on a un seule handler dans tout application life cycle de lapplication 
builder.Services
    .AddScoped<ISellerHandler, SellerHandler>()
    .AddScoped<ISellerRepository, MongoSellersRepository>();
    

//// Add MongoDb services to the container.
builder.Services.Configure<MongoDbConfiguration>(
    builder.Configuration.GetSection("MongoDBConfiguration"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
