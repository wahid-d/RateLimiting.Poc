using AspNetCoreRateLimit;
using System.Text;
using System.Text.Json;
using System.Web;

namespace RateLimiting.Poc
{
    public class NetworkFromBodyResolverContributer : IClientResolveContributor
    {
        public async Task<string> ResolveClientAsync(HttpContext httpContext)
        {
            using var sr = new StreamReader(httpContext.Request.Body);
            var body = await sr.ReadToEndAsync();

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(body));
            ms.Seek(0, SeekOrigin.Begin);

            httpContext.Request.Body = ms;

            if (string.IsNullOrWhiteSpace(body))
                return string.Empty;

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(body);
            var network = jsonElement.GetProperty("network").ToString().ToUpper();

            return network;
        }
    }
}
