using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Interfaces
{
    public interface IEnderecosViagemRepository
    {
        void Cadastrar(EnderecosViagem novoEndereco);
        void DeletarPelaViagem(Guid idViagem);
    }
}
