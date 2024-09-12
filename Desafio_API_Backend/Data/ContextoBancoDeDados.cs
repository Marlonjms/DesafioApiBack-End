using Desafio_API_Backend.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API_Backend.Data
{

    // A classe `ContextoBancoDeDados` gerencia a conexão e a interação com
    // o banco de dados, definindo como as entidades são mapeadas para as tabelas
    // e facilitando operações de leitura e escrita de dados.

    public class ContextoBancoDeDados : DbContext
    {
    
        public ContextoBancoDeDados(DbContextOptions<ContextoBancoDeDados> options) : base(options)
        {
        }


        // forma de criação da tabela Motos
        public DbSet<ModeloMoto> Motos { get; set; }
        // forma de criação da tabela locacoes
        public DbSet<ModeloLocacao> locacaos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura o relacionamento entre Locacao e Moto
            modelBuilder.Entity<ModeloLocacao>()
                .HasOne(l => l.MotoRelacionada)
                .WithMany(m => m.Alocacoes)
                .HasForeignKey(l => l.IdMoto);

            // Configura a coluna 'Placa' como única
            modelBuilder.Entity<ModeloMoto>()
                .HasIndex(m => m.Placa)
                .IsUnique();


        }
    }
}
