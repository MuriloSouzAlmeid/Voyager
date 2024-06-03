using Microsoft.EntityFrameworkCore;
using VoyagerWebApi.Domains;

namespace VoyagerWebApi.Contexts
{
    public class VoyagerContext : DbContext
    {
        public DbSet<Avaliacoes> Avaliacoes { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<EnderecosViagem> EnderecosViagem { get; set; }
        public DbSet<EnderecosUsuario> EnderecosUsuarios { get; set; }
        public DbSet<GaleriaImagens> GaleriaImagens { get; set; }
        public DbSet<Planejamentos> Planejamentos { get; set; }
        public DbSet<PostagensViagens> PostagensViagens { get; set; }
        public DbSet<StatusViagens> StatusViagens { get; set; }
        public DbSet<Atividade> TiposAtividade { get; set; }
        public DbSet<TiposViagem> TiposViagem { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Viagens> Viagens { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:voyagerserver.database.windows.net,1433;Initial Catalog=VoyagerDatabase;User ID=voyageradmin;Password=voyager123$;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
