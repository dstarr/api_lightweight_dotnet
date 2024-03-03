using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace TodoApi;

public static class RouteMapper
{
    public static void MapTodoRoutes(this RouteGroupBuilder routeGroupBuilder)
    {
        TodoApiApplication todoApiApplication = new();
            
        routeGroupBuilder.MapGet("/", todoApiApplication.GetAllTodos);
        routeGroupBuilder.MapGet("/complete", todoApiApplication.GetCompleteTodos);
        routeGroupBuilder.MapGet("/{id}", todoApiApplication.GetTodo);
        routeGroupBuilder.MapPost("/", todoApiApplication.CreateTodo);
        routeGroupBuilder.MapPut("/{id}", todoApiApplication.UpdateTodo);
        routeGroupBuilder.MapDelete("/{id}", todoApiApplication.DeleteTodo);

    }
}