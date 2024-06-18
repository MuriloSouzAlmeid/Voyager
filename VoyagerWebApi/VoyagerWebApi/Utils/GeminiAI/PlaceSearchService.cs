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
                    Temperature = 0.5,
                    CandidateCount = 1
                },
                Model = "gemini-1.5-pro"
            });
        }

        public async Task<List<PlaceSettings>> BuscarPontosTuristicos(string local)
        {
            string prompt = @$"
Me retorne uma lista em JSON das 6 melhores atividades para se fazer em pontos turísticos para se visitar no local que será informado a seguir. Caso não encontre este tanto de pontos turísticos, traga apenas o máximo que encontrar. O JSON representará uma lista de objetos e cada objeto deverá conter como propriedades o nome do ponto turístico, a cidade e país onde está situado, uma breve descrição do local e qual a atividade a se fazer no local. O nome dos atributos entao serao: nome, pais, cidade, descricao e atividade. Adicione também um atibuto chamado imagem contendo uma string vazia. Retorne o valor como um texto qualquer, no entanto simulando um json sem as crases no início e no final e iniciando e finalizando a resposta com colchetes []. Caso o local informado não exista no planeta Terra retorne como resposta: []. 

Exempo de Entrada: Paris

Exemplo de Saída:
[
{{
""nome"": ""Torre Eiffel"",
""pais"": ""França"",
""cidade"": ""Paris"",
""descricao"": ""A Torre Eiffel é um marco icônico de Paris e um dos monumentos mais famosos do mundo. Projetada por Gustave Eiffel para a Exposição Universal de 1889, a torre de ferro de 324 metros oferece vistas panorâmicas da cidade."",
""atividade"": ""Visitar os três níveis da torre, fazer um piquenique no Champ de Mars, admirar o pôr do sol sobre a cidade, subir de elevador ou escadas, visitar o restaurante no topo da torre."",
""imagem"": """"
}},
{{
""nome"": ""Museu do Louvre"",
""pais"": ""França"",
""cidade"": ""Paris"",
""descricao"": ""O Museu do Louvre é um dos museus de arte mais importantes do mundo, abrigando uma coleção de obras-primas de diferentes períodos e culturas, incluindo a Mona Lisa de Leonardo da Vinci."",
""atividade"": ""Visitar a Mona Lisa, explorar as coleções de arte antiga, egípcia, islâmica e medieval, admirar esculturas de Michelangelo, Veronese e outros artistas renomados, fazer um tour guiado pelo museu."",
""imagem"": """"
}},
{{
""nome"": ""Catedral de Notre Dame"",
""pais"": ""França"",
""cidade"": ""Paris"",
""descricao"": ""A Catedral de Notre Dame é uma catedral gótica de grande beleza arquitetônica e importância histórica. Seu interior abriga belos vitrais e esculturas, além de ser um local de eventos religiosos e culturais."",
""atividade"": ""Visitar a catedral, admirar os vitrais e esculturas, participar de uma missa, fazer um tour guiado pela catedral, subir até a torre para apreciar a vista da cidade."",
""imagem"": """"
}},
{{
""nome"": ""Arco do Triunfo"",
""pais"": ""França"",
""cidade"": ""Paris"",
""descricao"": ""O Arco do Triunfo é um monumento histórico dedicado às vitórias militares francesas. Localizado na Place Charles de Gaulles, ele oferece vistas panorâmicas da Champs-Élysées e de outras partes da cidade."",
""atividade"": ""Subir até o topo do arco para apreciar a vista panorâmica da cidade, fazer um tour guiado pelo arco, descobrir a história do monumento, admirar as esculturas e inscrições, desfrutar de um piquenique na Place Charles de Gaulles."",
""imagem"": """"
}},
{{
""nome"": ""Museu de Orsay"",
""pais"": ""França"",
""cidade"": ""Paris"",
""descricao"": ""O Museu de Orsay abriga uma coleção de arte impressionista e pós-impressionista, incluindo obras de Monet, Renoir, Degas, Cézanne e Van Gogh."",
""atividade"": ""Visitar as coleções de arte impressionista e pós-impressionista, admirar obras-primas como 'Impression, Soleil Levant' de Monet e 'A Noite Estrelada' de Van Gogh, fazer um tour guiado pelo museu, explorar a arquitetura da antiga estação ferroviária, desfrutar de um café no restaurante do museu."",
""imagem"": """"
}},
{{
""nome"": ""Champs-Élysées"",
""pais"": ""França"",
""cidade"": ""Paris"",
""descricao"": ""A Champs-Élysées é uma avenida icônica de Paris, conhecida por suas lojas de luxo, restaurantes, cafés e cinemas. É um local popular para passear, fazer compras e desfrutar da atmosfera da cidade."",
""atividade"": ""Passear pela avenida, fazer compras em boutiques de luxo, visitar lojas e restaurantes, assistir a um show no Théâtre Marigny, desfrutar de um café em um dos cafés da avenida."",
""imagem"": """"
}}
]

Exemplo de Entrada: Brasil

Exemplo de Saída:
[
{{
""nome"": ""Cristo Redentor"",
""pais"": ""Brasil"",
""cidade"": ""Rio de Janeiro"",
""descricao"": ""O Cristo Redentor é uma estátua art déco de Jesus Cristo, localizada no topo do Morro do Corcovado, no Parque Nacional da Tijuca, na cidade do Rio de Janeiro, no Brasil. É uma das novas Sete Maravilhas do Mundo Moderno, sendo um dos pontos turísticos mais famosos do Brasil e do mundo."",
""atividade"": ""Visitar a estátua, apreciar a vista panorâmica da cidade do Rio de Janeiro, fazer fotos, conhecer a história da construção da estátua."",
""imagem"": """"
}},
{{
""nome"": ""Pão de Açúcar"",
""pais"": ""Brasil"",
""cidade"": ""Rio de Janeiro"",
""descricao"": ""O Pão de Açúcar é um morro no Rio de Janeiro, Brasil, com dois picos, um com 396 metros de altitude e o outro com 238 metros. É um dos principais pontos turísticos da cidade, conhecido por sua beleza natural e por oferecer uma vista panorâmica deslumbrante da cidade."",
""atividade"": ""Subir de bondinho até o topo do morro, apreciar a vista panorâmica da cidade do Rio de Janeiro, fazer trilhas, praticar esportes de aventura, conhecer a história do Pão de Açúcar."",
""imagem"": """"
}},
{{
""nome"": ""Amazonas"",
""pais"": ""Brasil"",
""cidade"": ""Manaus"",
""descricao"": ""A Amazônia é a maior floresta tropical do mundo, localizada na América do Sul e abrangendo nove países, sendo o Brasil o país com a maior parte da floresta. A região é conhecida por sua rica biodiversidade, com milhares de espécies de plantas e animais, e por sua importância para o equilíbrio do clima global."",
""atividade"": ""Fazer um cruzeiro pelo Rio Amazonas, observar a fauna e flora da floresta, conhecer comunidades indígenas, praticar pesca esportiva, fazer trilhas ecológicas."",
""imagem"": """"
}},
{{
""nome"": ""Foz do Iguaçu"",
""pais"": ""Brasil"",
""cidade"": ""Foz do Iguaçu"",
""descricao"": ""Foz do Iguaçu é uma cidade brasileira no estado do Paraná, conhecida por abrigar as Cataratas de Foz do Iguaçu, uma das maiores e mais impressionantes cachoeiras do mundo. O Parque Nacional do Iguaçu, onde se encontram as cataratas, é um dos principais destinos turísticos do Brasil e do mundo."",
""atividade"": ""Visitar as Cataratas de Foz do Iguaçu, fazer um passeio de barco pelas cachoeiras, apreciar a fauna e flora da região, praticar esportes de aventura, conhecer a história da região."",
""imagem"": """"
}},
{{
""nome"": ""Salvador"",
""pais"": ""Brasil"",
""cidade"": ""Salvador"",
""descricao"": ""Salvador é a capital do estado da Bahia, no Brasil. É uma cidade com grande riqueza cultural e histórica, com construções coloniais, museus, igrejas, e uma vida noturna vibrante. A cidade é conhecida por suas praias, sua culinária e por seus eventos culturais."",
""atividade"": ""Visitar o Pelourinho, conhecer a história da cidade, apreciar a culinária baiana, curtir as praias, assistir a shows de música e dança, visitar museus."",
""imagem"": """"
}},
{{
""nome"": ""Brasília"",
""pais"": ""Brasil"",
""cidade"": ""Brasília"",
""descricao"": ""Brasília é a capital do Brasil, projetada pelo arquiteto Oscar Niemeyer e urbanista Lúcio Costa. A cidade é conhecida por sua arquitetura moderna, seus edifícios icônicos, seus parques e jardins, e sua vida cultural."",
""atividade"": ""Visitar os principais monumentos da cidade, como o Palácio do Planalto, o Congresso Nacional e a Catedral Metropolitana, conhecer a história da cidade, apreciar a arquitetura moderna, passear pelos parques e jardins, assistir a shows e eventos culturais."",
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
