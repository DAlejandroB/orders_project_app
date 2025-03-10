using Microsoft.EntityFrameworkCore;
using orders_project_app.Data;
using orders_project_app.Repository.Implementation;
using orders_project_app.Repository.Interface;
using orders_project_app.Service.Implementation;
using orders_project_app.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OrdersAppDb>(options => options.UseSqlServer(connectionString));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            policy => policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());
    });
}

// Add repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IStockItemRepository, StockItemRepository>();

// Add services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IStockItemService, StockItemService>();

//Add controllers **Note: This is performed automatically**
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
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
