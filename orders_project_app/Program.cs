using Microsoft.EntityFrameworkCore;
using orders_project_app.Data;
using orders_project_app.Repository.Implementation;
using orders_project_app.Repository.Interface;
using orders_project_app.Service.Implementation;
using orders_project_app.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OrdersAppDb>(options => options.UseSqlServer(connectionString));

// Add repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Add services
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers();
var app = builder.Build();


app.MapControllers();

app.Run();
