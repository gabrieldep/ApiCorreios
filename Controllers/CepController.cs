using DotNet.CEP.Search.App;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiCorreios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ILogger<CepController> _logger;

        public CepController(ILogger<CepController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAdressRawData")]
        public async Task<IActionResult> GetAsync(string cep, bool isRawData)
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            _logger.LogInformation($"Request from {remoteIpAddress}- CEP to search: {cep}");

            var cepSearch = new CepSearch();
            if (isRawData)
                return StatusCode((int)HttpStatusCode.OK, await cepSearch.GetAddressByCepRawDataAsync(cep));
            return StatusCode((int)HttpStatusCode.OK, await cepSearch.GetAddressByCepAsync(cep));
        }
    }
}
