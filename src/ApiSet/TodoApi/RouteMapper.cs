using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Patterns;

namespace TodoApi;

public static class RouteMapper
{
    public static void MapTodoRoutes(this RouteGroupBuilder routeGroupBuilder)
    {
        TodoApplication todoApplication = new();
            
        routeGroupBuilder.MapGet("/", todoApplication.GetAllTodos);
        routeGroupBuilder.MapGet("/complete", todoApplication.GetCompleteTodos);
        routeGroupBuilder.MapGet("/{id}", todoApplication.GetTodo);
        routeGroupBuilder.MapPost("/", todoApplication.CreateTodo);
        routeGroupBuilder.MapPut("/{id}", todoApplication.UpdateTodo);
        routeGroupBuilder.MapDelete("/{id}", todoApplication.DeleteTodo);

    }
}