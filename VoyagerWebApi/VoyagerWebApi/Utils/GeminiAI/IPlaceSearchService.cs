namespace VoyagerWebApi.Utils.GeminiAI
{
    public interface IPlaceSearchService
    {
        Task<PlaceSettings[]> BuscarPontosTuristicos(string local);
    }
}
