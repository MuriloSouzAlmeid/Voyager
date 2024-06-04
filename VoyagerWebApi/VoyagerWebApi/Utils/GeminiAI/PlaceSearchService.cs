using GenerativeAI.Models;
using GenerativeAI.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VoyagerWebApi.Utils.GeminiAI
{
    public class PlaceSearchService : IPlaceSearchService
    {
        private readonly string apiKeyGemini;
        private readonly IImageSearchService _imageSearch;
        public GenerativeModel modelo {  get; set; }

        public PlaceSearchService()
        {
            apiKeyGemini = "AIzaSyCAMtSLTyOYk4DaIv--qxX8eZ7dZ2XpGzk";
            _imageSearch = new ImageSearchService();
            modelo = new GenerativeModel(apiKeyGemini, new ModelParams()
            {
                GenerationConfig = new GenerationConfig()
                {
                    Temperature = 0,
                    CandidateCount = 1
                },
                Model = "gemini-1.5-pro"
            });
        }

        public async Task<List<PlaceSettings>> BuscarPontosTuristicos(string local)
        {
            var resposta = await modelo.GenerateContentAsync($"Me retorne uma lista em JSON dos 5 melhores pontos turísticos para se visitar em {local}. O JSON representará uma lista de objetos e cada objeto deverá conter como propriedades o nome do ponto turístico, a cidade e país onde está situado e uma breve descrição do local. O nome dos atributos entao serao: nome, pais, cidade, descricao. Adicione também um atibuto chamado imagem contendo uma string vazia. Retorne o valor como um texto qualquer, no entanto simulando um json sem as crases no início e no final e iniciando e finalizando a resposta com colchetes []. Caso o local informado não exista no planeta Terra retorne como resposta: [].");

            List<PlaceSettings> listaPontosTuristicos = new List<PlaceSettings>();

            PlaceSettings[] arrayDePontosTuristicos = JsonConvert.DeserializeObject<PlaceSettings[]>(resposta);

            if (arrayDePontosTuristicos.Length != 0) {
                foreach (PlaceSettings pontoTuristico in arrayDePontosTuristicos)
                {
                    pontoTuristico.imagem = await _imageSearch.BuscarImagem($"{pontoTuristico.nome}, em {pontoTuristico.cidade}");
                    listaPontosTuristicos.Add(pontoTuristico);
                }
            }

            return listaPontosTuristicos;
        }
    }
}
