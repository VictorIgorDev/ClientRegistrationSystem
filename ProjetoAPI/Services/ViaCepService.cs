using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Services
{
    public class ViaCepService
    {
        public EnderecoDto? ObterEndereco(string cep)
        {
            
            var result = new HttpClient().GetAsync

            ("https://viacep.com.br/ws/" + cep + "/json/").Result;
            
            return JsonConvert.DeserializeObject<EnderecoDto>
            (result.Content.ReadAsStringAsync().Result);
        }
    }
    
    public class EnderecoDto
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public string? Ibge { get; set; }
        public string? Gia { get; set; }
        public string? Ddd { get; set; }
        public string? Siafi { get; set; }
    }
}
