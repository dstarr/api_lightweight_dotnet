using AutoApi;
using AutoApi.Data;
using Microsoft.EntityFrameworkCore;
using TodoApi;
using TodoApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoListDb"));
builder.Services.AddDbContext<AutoDb>(opt => opt.UseInMemoryDatabase("AutoDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("/todo").MapTodoRoutes();
app.MapGroup("/autos").MapAutoRoutes();


app.Run();