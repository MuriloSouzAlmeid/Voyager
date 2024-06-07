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
            string prompt = @$"
Me retorne uma lista em JSON das 6 melhores atividades para se fazer em pontos turísticos para se visitar no local que será informado a seguir. Caso não encontre este tanto de pontos turísticos, traga apenas o máximo que encontrar. O JSON representará uma lista de objetos e cada objeto deverá conter como propriedades o nome do ponto turístico, a cidade, país e logradouro onde está situado, uma breve descrição do local e qual a atividade a se fazer no local incluindo o nome do local. O nome dos atributos entao serao: nome, pais, cidade, logradouro, descricao e atividade. Adicione também um atibuto chamado imagem contendo uma string vazia. Retorne o valor como um texto qualquer, no entanto simulando um json sem as crases no início e no final e iniciando e finalizando a resposta com colchetes []. Caso o local informado não exista no planeta Terra retorne como resposta: []. 

Exempo de Entrada: Roma

Exemplo de Saída:
[
{{
""nome"": ""Coliseu"",
""pais"": ""Itália"",
""cidade"": ""Roma"",
""logradouro"": ""Piazza del Colosseo, 1"",
""descricao"": ""Um antigo anfiteatro romano que já recebeu gladiadores, batalhas navais simuladas e outros espetáculos grandiosos. É um ícone da Roma Antiga e um dos monumentos mais visitados do mundo."",
""atividade"": ""Visitar o Coliseu"",
""imagem"": """"
}},
{{
""nome"": ""Vaticano"",
""pais"": ""Vaticano"",
""cidade"": ""Cidade do Vaticano"",
""logradouro"": ""Piazza San Pietro"",
""descricao"": ""Um estado independente dentro de Roma, o Vaticano é a sede da Igreja Católica e a residência do Papa. A Basílica de São Pedro, a Capela Sistina e os Museus do Vaticano estão entre as principais atrações."",
""atividade"": ""Visitar a Cidade do Vaticano"",
""imagem"": """"
}},
{{
""nome"": ""Panteão"",
""pais"": ""Itália"",
""cidade"": ""Roma"",
""logradouro"": ""Piazza della Rotonda"",
""descricao"": ""Um templo romano incrivelmente bem preservado com uma cúpula de concreto impressionante. O Panteão é um feito da arquitetura romana e um lugar tranquilo para se visitar."",
""atividade"": ""Visitar o Panteão"",
""imagem"": """"
}}
]

Exempo de Entrada: Paris

Exemplo de Saída:
[
  {{
    ""nome"": ""Torre Eiffel"",
    ""pais"": ""França"",
    ""cidade"": ""Paris"",
    ""descricao"": ""Uma torre treliçada de ferro do século XIX que se tornou um ícone global de França e um dos edifícios mais reconhecíveis do mundo."",
    ""atividade"": ""Visitar a Torre Eiffel"",
    ""imagem"": """"
  }},
  {{
    ""nome"": ""Museu do Louvre"",
    ""pais"": ""França"",
    ""cidade"": ""Paris"",
    ""descricao"": ""O museu de arte mais visitado do mundo, lar de obras-primas como a Mona Lisa e a Vénus de Milo."",
    ""atividade"": ""Visitar o Museu do Louvre"",
    ""imagem"": """"
  }},
  {{
    ""nome"": ""Arco do Triunfo"",
    ""pais"": ""França"",
    ""cidade"": ""Paris"",
    ""descricao"": ""Um arco triunfal do século XIX encomendado por Napoleão Bonaparte para comemorar as suas vitórias militares."",
    ""atividade"": ""Visitar o Arco do Triunfo"",
    ""imagem"": """"
  }}
]

Exemplo de Entrada: {local}
";

            var resposta = await modelo.GenerateContentAsync(prompt);

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
