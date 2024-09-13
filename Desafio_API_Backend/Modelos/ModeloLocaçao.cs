using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_API_Backend.Modelos
{
    public class ModeloLocaçao
    {

        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        public int IdMoto { get; set; }

        public DateTime DataLocao { get; set; }

        // Relacionamento com a tabela motos
        public ModeloMoto MotoRelacionada { get; set; }




    }
}
