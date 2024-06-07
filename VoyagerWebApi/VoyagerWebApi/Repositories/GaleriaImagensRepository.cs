using Microsoft.EntityFrameworkCore;
using VoyagerWebApi.Contexts;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Interfaces;

namespace VoyagerWebApi.Repositories
{
    public class GaleriaImagensRepository : IGaleriaImagensRepository
    {
        private readonly VoyagerContext _context;

        public GaleriaImagensRepository()
        {
            _context = new VoyagerContext();
        }
        public GaleriaImagens BuscarFotoPorId(Guid ID)
        {
            try
            {
                GaleriaImagens fotoBuscada = _context.GaleriaImagens.FirstOrDefault(x => x.ID == ID)!;

                if (fotoBuscada == null)
                {
                    return null;
                }

                return fotoBuscada;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CadastrarFoto(GaleriaImagens novaImagem)
        {
            _context.GaleriaImagens.Add(novaImagem);

            _context.SaveChanges();
        }

        public void Deletar(Guid ID)
        {
            GaleriaImagens fotoBuscada = _context.GaleriaImagens.FirstOrDefault(x => x.ID == ID)!;

            if (fotoBuscada != null)
            {
                _context.GaleriaImagens.Remove(fotoBuscada);

                _context.SaveChanges();
            }
        }

        public List<GaleriaImagens> ListarPorPostagem(Guid idPostagem)
        {
            List<GaleriaImagens> listaDeFotos = _context.GaleriaImagens.Where(a => a.IdPostagemViagem == idPostagem).ToList();
            return listaDeFotos;
        }
    }
}
