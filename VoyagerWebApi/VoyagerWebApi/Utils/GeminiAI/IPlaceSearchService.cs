namespace VoyagerWebApi.Utils.GeminiAI
{
    public interface IPlaceSearchService
    {
        Task<List<PlaceSettings>> BuscarPontosTuristicos(string local);
    }
}
