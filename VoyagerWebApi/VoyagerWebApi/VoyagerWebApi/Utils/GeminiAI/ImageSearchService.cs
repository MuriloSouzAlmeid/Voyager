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
            apiKeySearch = "AIzaSyAqQE1wjBU7i-IgTueftVs1ZsWfa0-okHM";
            idSearchMotor = "42637b5d6992148c4";

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

        public async Task<List<string>> BuscarImagensLocal(string local)
        {
            string urlBusca = $"https://www.googleapis.com/customsearch/v1?key=AIzaSyAqQE1wjBU7i-IgTueftVs1ZsWfa0-okHM&cx=42637b5d6992148c4&q={Uri.EscapeDataString(local)}&searchType=image";

            List<string> listaDeImagens = new List<string>();

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(urlBusca);

                if (response.IsSuccessStatusCode)
                {
                    string conteudoJson = await response.Content.ReadAsStringAsync();
                    JObject respostaJson = JsonConvert.DeserializeObject<JObject>(conteudoJson)!;

                    if (respostaJson["items"] != null)
                    {
                        for(int i = 0; i < 5; i++)
                        {
                            JToken item = respostaJson["items"]![i]!;
                            listaDeImagens.Add(item["link"]!.ToString());
                        }
                    }
                    else
                    {
                        listaDeImagens.Add("Url não encontrada");
                    }
                }
                else
                {
                    listaDeImagens.Add("Erro ao buscar imagem");
                }
            }

            return listaDeImagens;
        }
    }
}
