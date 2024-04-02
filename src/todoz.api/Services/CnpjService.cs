using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ampare.api.Services
{
    public class CnpjService
    {
        private readonly HttpClient _httpClient;

        public CnpjService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCompanyName(string cnpj)
        {
            try
            {
                string apiUrl = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic responseData = JsonConvert.DeserializeObject(jsonResponse);

                    // Verifica se a propriedade 'nome' está presente no JSON
                    if (responseData.nome != null)
                    {
                        return responseData.nome;
                    }
                    else
                    {
                        throw new Exception("O nome da empresa não foi encontrado no JSON retornado.");
                    }
                }
                else
                {
                    throw new HttpRequestException($"Failed to fetch company data. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while fetching company data: {ex.Message}");
            }
        }
    }
}
