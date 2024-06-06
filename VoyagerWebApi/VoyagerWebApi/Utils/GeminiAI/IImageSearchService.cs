namespace VoyagerWebApi.Utils.GeminiAI
{
    public interface IImageSearchService
    {
        Task<string> BuscarImagem(string local);
    }
}
