using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IViagensRepository
    {
        void CadastrarViagem(Viagens novaViagem);

        void DeletarViagem(Guid idViagem);

        Viagens BuscarPorId(Guid idViagem);
    }
}
