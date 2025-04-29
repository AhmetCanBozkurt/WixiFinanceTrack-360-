using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wixi.financeApp.DataAccess.Context;
using wixi.financeApp.Entities.Modals;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Burada dependecy Injection ile default olarak ayarlardan hangi veritabaný baðlantýsýna gideceðine dair bilgisini verdik.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Server=213.142.148.127;Database=wixi.financeapp;User ID=wixi.finansapp;Password=3&K!c$v3y3yj;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");

});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddSwaggerGen();

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
