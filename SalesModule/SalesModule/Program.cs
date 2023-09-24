using Microsoft.EntityFrameworkCore;
using SaleModule.Models;
using SalesModule.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<AppDbContext>();
var constr = builder.Configuration.GetConnectionString("SalesModule");
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(constr));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

