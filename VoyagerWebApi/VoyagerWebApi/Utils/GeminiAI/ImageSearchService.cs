using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace VoyagerWebApi.Utils.GeminiAI
{
    public class ImageSearchService : IImageSearchService
    {
        private readonly string apiKeySearch;
        private readonly string idSearchMotor;

        public ImageSearchService()
        {
            apiKeySearch = "AIzaSyBq-z7CPO-ZwdPQ9oLm6XRz0Dcl6SvZJHw";
            idSearchMotor = "876cc24e0e9ba4108";

        }

        public async Task<string> BuscarImagem(string local)
        {
            string urlBusca = $"https://www.googleapis.com/customsearch/v1?key={apiKeySearch}&cx={idSearchMotor}&q={Uri.EscapeDataString(local)}&searchType=image";

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(urlBusca);

                if (response.IsSuccessStatusCode)
                {
                    string conteudoJson = await response.Content.ReadAsStringAsync();
                    JObject respostaJson = JsonConvert.DeserializeObject<JObject>(conteudoJson)!;

                    if (respostaJson["items"] != null)
                    {
                        JToken item = respostaJson["items"]![0]!;
                        return item["link"]!.ToString();
                    }
                    else
                    {
                        return "Url não encontrada";
                    }
                }
                else
                {
                    return "Erro ao buscar imagem";
                }
            }
        }
    }
}
