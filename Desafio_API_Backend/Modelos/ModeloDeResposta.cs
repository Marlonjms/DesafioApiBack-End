namespace Desafio_API_Backend.Modelos
{

    // esse modelo de resposta é do tipo generico, pode servir tanto para motos quanto para locacao...
    public class ModeloDeResposta<T>
    {   // dados pode ser nulo, caso não encontre algum dado no banco, se houver algum erro...
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

    }
}
