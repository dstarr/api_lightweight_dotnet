using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace AutoApi;

public static class RouteMapper
{
    public static void MapAutoRoutes(this RouteGroupBuilder routeGroupBuilder)
    {
        AutoApiApplication autoApi = new();
            
        routeGroupBuilder.MapGet("/", autoApi.GetAllAutos);
        routeGroupBuilder.MapPost("/", autoApi.CreateAuto);
        

    }
}