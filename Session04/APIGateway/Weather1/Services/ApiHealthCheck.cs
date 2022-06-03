using Microsoft.Extensions.Diagnostics.HealthChecks;

public class ApiHealthCheck : IHealthCheck
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ApiHealthCheck(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        using (var httpClient = _httpClientFactory.CreateClient())
        {
            var response = await httpClient.GetAsync("https://localhost:7004/status");
            if (response.IsSuccessStatusCode)
            {
                return HealthCheckResult.Healthy($"API is running.");
            }

            return HealthCheckResult.Unhealthy("API is not running");
        }
    }
}