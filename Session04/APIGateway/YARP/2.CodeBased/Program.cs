using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

var routes = new[]
{
    new RouteConfig()
    {
        RouteId = "route1",
        ClusterId = "cluster1",
        Match = new RouteMatch
        {
            Path = "/weather/v1"
        }
    },
    new RouteConfig()
    {
        RouteId = "route2",
        ClusterId = "cluster2",
        Match = new RouteMatch
        {
            Path = "/weather/v2"
        }
    }
};
var clusters = new[]
{
    new ClusterConfig()
    {
        ClusterId = "cluster1",
        Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase)
        {
            { "destination1", new DestinationConfig() { Address = "https://localhost:7001/api" } }
        }
    },
    new ClusterConfig()
    {
        ClusterId = "cluster2",
        Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase)
        {
            { "destination2", new DestinationConfig() { Address = "https://localhost:7002/api" } }
        }
    }
};

builder.Services.AddReverseProxy()
    .LoadFromMemory(routes, clusters);

var app = builder.Build();
app.MapReverseProxy();
app.Run();