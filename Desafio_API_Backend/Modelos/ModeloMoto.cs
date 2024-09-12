using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Desafio_API_Backend.Modelos
{
    public class ModeloMoto
    {   
        //configura para que a coluna id seja a chave pimaria e, seja auto incrmento!
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }

        // defini que esse campo seja obrigatorio
        [Required]
        public string Placa { get; set; }

        //com essa propriedade, não vai ser necessario quando eu cadastrar as motos, já preencher as aloções.
        [JsonIgnore]
        
        //relacionameto com Locações, uma moto pode ter varias locações.
        public ICollection<ModeloLocacao> Alocacoes { get; set; }
    }
}
