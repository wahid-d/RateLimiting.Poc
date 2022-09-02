using Microsoft.AspNetCore.Mvc;

namespace RateLimiting.Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateLimitController : ControllerBase
    {

        [HttpPost("[action]")]
        public IActionResult Mint([FromBody]MintModel model) => Ok(model);

        [HttpPost("[action]")]
        public IActionResult Burn([FromQuery]string amount, [FromQuery]string network) => Ok(new MintModel { Amount = amount, Network = network });
    }

    public class MintModel
    {
        public string? Network { get; set; }
        public string? Amount { get; set; }
    }
}
