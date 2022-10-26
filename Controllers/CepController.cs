using ApiCorreios.Models;
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
        public async Task<IActionResult> GetAsync(string cep, bool isRawData, Enums.CepType? cepType)
        {
            if (Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedIps))
            {
                var senderIpv4 = forwardedIps.First();
                _logger.LogInformation($"Request from {senderIpv4}- Info to search: {cep} ");
            }

            var cepSearch = new CepSearch();
            var rawData = await cepSearch.GetAddressByCepRawDataAsync(cep);
            if (isRawData)
                return StatusCode((int)HttpStatusCode.OK, rawData);
            var processedData = CepService.ProcessData(rawData);
            processedData = processedData.Where(p => cepType == null || p.CepType == cepType.ToString());
            return StatusCode((int)HttpStatusCode.OK, processedData);
        }
    }
}
