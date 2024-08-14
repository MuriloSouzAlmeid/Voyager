using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IStatusViagensRepository
    {
        StatusViagens BuscarStatus(string statusNome);
        void StatusIniciarViagem(Guid idViagem);
        void StatusConcluirViagem(Guid idViagem);
    }
}
