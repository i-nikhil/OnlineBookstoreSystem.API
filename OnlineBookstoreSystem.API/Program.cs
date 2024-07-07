using Microsoft.OpenApi.Models;
using OnlineBookstoreSystem.API.Middlewares;
using OnlineBookstoreSystem.API.Repositories;
using OnlineBookstoreSystem.API.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Online Bookstore API",
        Description = "The Mini Online Bookstore System is a simplified RESTful API that manages books, users, and orders. It includes functionalities to add and display books, register users, and handle order placements and calculations, demonstrating object-oriented principles and basic error handling without a GUI or database backend.",
        Version = "v1" });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Register repositories
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

// Register services
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use custom exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
