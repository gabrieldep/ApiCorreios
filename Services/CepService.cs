using ApiCorreios.Models;
using DotNet.CEP.Search.App.Models;

namespace ApiCorreios.Services
{
    public static class CepService
    {
        public static IEnumerable<ProcessedAddress> ProcessData(ResponseCorreios rawData)
        {
            var processedAddress = new List<ProcessedAddress>();
            foreach (var item in rawData.Dados)
            {
                ProcessedAddress address;
                if (string.IsNullOrEmpty(item.Bairro) && string.IsNullOrEmpty(item.LocalidadeSubordinada))
                {
                    address = new()
                    {
                        Bairro = null,
                        Cep = item.Cep,
                        Cidade = item.Localidade,
                        Rua = null,
                        Uf = item.Uf,
                        CepType = Enums.CepType.Cidade.ToString()
                    };
                }
                else if (string.IsNullOrEmpty(item.Bairro) && !string.IsNullOrEmpty(item.Localidade) && !string.IsNullOrEmpty(item.LocalidadeSubordinada))
                {
                    address = new()
                    {
                        Bairro = item.Localidade,
                        Cep = item.Cep,
                        Cidade = item.LocalidadeSubordinada,
                        Rua = null,
                        Uf = item.Uf,
                        CepType = Enums.CepType.Bairro.ToString()
                    };
                }
                else
                {
                    address = new()
                    {
                        Bairro = item.Bairro,
                        Cep = item.Cep,
                        Cidade = item.Localidade,
                        Rua = item.LogradouroDNEC,
                        Uf = item.Uf,
                        CepType = Enums.CepType.Rua.ToString()
                    };
                }

                processedAddress.Add(address);
            }
            return processedAddress;
        }

    }
}
