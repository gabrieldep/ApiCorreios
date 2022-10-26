using ApiCorreios.Services;
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

        [HttpGet(Name = "GetAdress")]
        public async Task<IActionResult> GetAsync(string cep, bool isRawData)
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
            _logger.LogInformation($"Request from {remoteIpAddress}- CEP to search: {cep}");

            var cepSearch = new CepSearch();
            var rawData = await cepSearch.GetAddressByCepRawDataAsync(cep);
            if (isRawData)
                return StatusCode((int)HttpStatusCode.OK, rawData);
            return StatusCode((int)HttpStatusCode.OK, CepService.ProcessData(rawData));
        }
    }
}
