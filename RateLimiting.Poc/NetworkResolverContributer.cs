using AspNetCoreRateLimit;
using System.Web;

namespace RateLimiting.Poc
{
    public class NetworkResolverContributer : IClientResolveContributor
    {
        public async Task<string> ResolveClientAsync(HttpContext httpContext)
        {
            var network = HttpUtility.ParseQueryString(httpContext.Request.QueryString.Value).Get("network");
            
            network = network?.ToUpper() ?? string.Empty;

            return await Task.FromResult<string>(network ?? string.Empty);
        }
    }
}
