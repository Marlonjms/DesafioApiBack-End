using Desafio_API_Backend.Data;
using Desafio_API_Backend.Modelos;

namespace Desafio_API_Backend.Serviços.Moto
{
    public class MotoServiços : MotoInterface
    {


        private readonly ContextoBancoDeDados _contexto;
        //dando acesso ao banco de dados (ContextoBancoDeDados)
        public MotoServiços( ContextoBancoDeDados contexo)
        {
            
            _contexto = contexo;

        }



        public Task<ModeloDeResposta<ModeloMoto>> BuscarPorPlaca(string Placa)
        {
            throw new NotImplementedException();
        }

        //get buscar todas as motas
        public Task<ModeloDeResposta<List<ModeloMoto>>> ListarTodasMotos()
        {

            ModeloDeResposta<List<ModeloMoto>> resposta = new ModeloDeResposta<List<ModeloMoto>>();

            // tratamento de erros: 
            // vamos tentar realizar uma operação...
           try
            {

            }
            // se não e certo cairemos aqui!
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
                

            }
            //48:12
    }
}
