using CoWork.Application.Interfaces;
using CoWork.Infrastructure.Repositories;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

var privateKeyBytes = File.ReadAllBytes("Keys/private.key");

var publicKeyBytes = File.ReadAllBytes("Keys/public.key");
var rsa = RSA.Create();
rsa.ImportRSAPrivateKey(privateKeyBytes, out _);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<RSA>(rsa);
builder.Services.AddScoped(typeof(IGenericRepository<,>),typeof(GenericRepository<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
