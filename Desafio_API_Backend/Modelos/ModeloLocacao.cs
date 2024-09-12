namespace Desafio_API_Backend.Modelos
{
    public class ModeloLocacao
    {
        public int id { get; set; }
        public DateTime DataLocao { get; set; }
        public int IdMoto { get; set; }

        // relacionamento com a tabela motos

        public ModeloMoto MotoRelacionada { get; set; }


    }
}
