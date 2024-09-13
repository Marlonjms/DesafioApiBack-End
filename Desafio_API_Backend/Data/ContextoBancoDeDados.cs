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
        public DbSet<ModeloLocaçao> locacaos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Define uma chave primária composta para ModeloLocaçao
            modelBuilder.Entity<ModeloLocaçao>()
                .HasKey(l => new { l.Id, l.IdMoto });

            // Configura o relacionamento entre Locacao e Moto
            modelBuilder.Entity<ModeloLocaçao>()
                .HasOne(l => l.MotoRelacionada)
                .WithMany(m => m.Alocacoes)
                .HasForeignKey(l => l.IdMoto);

            // Configura a coluna 'Placa' como única para ModeloMoto
            modelBuilder.Entity<ModeloMoto>()
                .HasIndex(m => m.Placa)
                .IsUnique();




        }
    }
}
