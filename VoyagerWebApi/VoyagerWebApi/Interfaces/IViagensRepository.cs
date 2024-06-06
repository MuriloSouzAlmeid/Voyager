using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IViagensRepository
    {
        void CadastrarViagem(Viagens novaViagem);

        void DeletarViagem(Guid idViagem);

        Viagens BuscarPorId(Guid idViagem);

        Viagens BuscarViagemEmAndamento(Guid idUsuario);

        List<Viagens> ListarViagensConcluidas(Guid idUsuario);

        List<Viagens> ListarViagensPendentes(Guid idUsuario);
    }
}
