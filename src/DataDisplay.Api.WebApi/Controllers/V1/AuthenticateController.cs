using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DataDisplay.Api.WebApi.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        protected readonly ILogger<AuthenticateController> Logger;

        public AuthenticateController(ILogger<AuthenticateController> logger)
        {
            Logger = logger;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test(CancellationToken cancellationToken)
        {
            return Ok("SucceedeD");
        }
    }
}