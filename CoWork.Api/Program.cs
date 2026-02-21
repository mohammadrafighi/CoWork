using CoWork.Application.Features.Auth.Command.CahngePassword;
using CoWork.Application.Features.Members.Command.CreateMember;
using CoWork.Application.Interfaces;
using CoWork.Infrastructure.Identity;
using CoWork.Infrastructure.Persistence;
using CoWork.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using System.Reflection;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

var privateKeyBytes = File.ReadAllBytes("IdentityKeys/private.key");

var publicKeyBytes = File.ReadAllBytes("IdentityKeys/public.key");
var rsa = RSA.Create();
rsa.ImportRSAPrivateKey(privateKeyBytes, out _);

// Add services to the container.

builder.Services.AddDataProtection();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentityCore<IdentityUser<Guid>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
    .AddRoles<IdentityRole<Guid>>() // اگر نقش دارین
    .AddEntityFrameworkStores<AppDbContext>() // DbContext شما
    .AddDefaultTokenProviders();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

//builder.Services.AddMediatR(cfg =>
//{
//    cfg.RegisterServicesFromAssemblyContainin<ChangePasswordCommandHandler>();
//});
builder.Services.AddMediatR(typeof(CreateMemberCommandHandler).GetTypeInfo().Assembly);
builder.Services.AddOpenApi();
builder.Services.AddSingleton<RSA>(rsa);
builder.Services.AddScoped(typeof(IGenericRepository<,>),typeof(GenericRepository<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoWork API", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT Bearer token **_only_**"
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

   

});


var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

    app.UseHttpsRedirection();

    app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

    app.Run();

