using Microsoft.EntityFrameworkCore;
using orders_project_app.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OrdersAppDb>(options => options.UseSqlServer(connectionString));

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
