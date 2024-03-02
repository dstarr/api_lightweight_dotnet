// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/route-handlers?view=aspnetcore-8.0
using Microsoft.EntityFrameworkCore;
using TodoApi.TodoApi.Data;
using TodoApi.TodoApi.DTOs;
using TodoApi.TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

RouteGroupBuilder todoItems = app.MapGroup("/todoitems");
TodoApi.TodoApi.App todoApiApp = new(todoItems);


app.Run();
