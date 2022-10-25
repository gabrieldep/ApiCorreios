namespace ApiCorreios.Models
{
    public class ProcessedAddress
    {
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Cep { get; set; }
        public string? Uf { get; set; }
        public string CepType { get; set; }
    }
}
