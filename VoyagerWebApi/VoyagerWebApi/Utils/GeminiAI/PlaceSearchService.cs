using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VoyagerWebApi.Utils.GeminiAI
{
    public class PlaceSearchService : IPlaceSearchService
    {
        private readonly string apiKeyGemini;

        public PlaceSearchService()
        {
            apiKeyGemini = "AIzaSyCAMtSLTyOYk4DaIv--qxX8eZ7dZ2XpGzk";
        }

        public Task<PlaceSettings[]> BuscarPontosTuristicos(string local)
        {
            throw new NotImplementedException();
        }
    }
}
