using DataDisplay.Application.Contract.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DataDisplay.Api.WebApi.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class DataController : ControllerBase
    {
        protected readonly ILogger<DataController> Logger;
        protected readonly IDataService DataService;

        public DataController(ILogger<DataController> logger, IDataService dataService)
        {
            Logger = logger;
            DataService = dataService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok((await DataService.GetAll()).Value);
        }
    }
}