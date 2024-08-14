namespace VoyagerWebApi.Utils.GeminiAI
{
    public interface IImageSearchService
    {
        Task<string> BuscarImagem(string local);
        Task<List<string>> BuscarImagensLocal(string local);
    }
}
