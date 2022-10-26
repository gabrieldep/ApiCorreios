using ApiCorreios.Services;
using DotNet.CEP.Search.App;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var cepSearch = new CepSearch();
            var rawData = await cepSearch.GetAddressByCepRawDataAsync(cep);
            _logger.LogInformation($"Info to search: {cep} \n Response: {JsonConvert.SerializeObject(rawData)}");

            if (isRawData)
                return StatusCode((int)HttpStatusCode.OK, rawData);
            return StatusCode((int)HttpStatusCode.OK, CepService.ProcessData(rawData));
        }
    }
}
