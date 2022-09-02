using AspNetCoreRateLimit;
using Microsoft.Extensions.Options;

namespace RateLimiting.Poc
{
    public class NetworkRateLimitConfiguration : RateLimitConfiguration
    {
        public NetworkRateLimitConfiguration(IOptions<IpRateLimitOptions> ipOptions, IOptions<ClientRateLimitOptions> clientOptions) : base(ipOptions, clientOptions)
        {
        }

        public override void RegisterResolvers()
        {
            base.RegisterResolvers();

            ClientResolvers.Add(new NetworkResolverContributer());
            ClientResolvers.Add(new NetworkFromBodyResolverContributer());
        }
    }
}
