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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Orders API");
        options.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();
