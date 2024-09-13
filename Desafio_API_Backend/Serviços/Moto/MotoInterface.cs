using Desafio_API_Backend.Dto;
using Desafio_API_Backend.Modelos;

namespace Desafio_API_Backend.Serviços.Moto
{
    public interface MotoInterface
    {
        //listar todas as motos cadastradas.
        Task<ModeloDeResposta<List<ModeloMoto>>> ListarTodasMotos();
        Task<ModeloDeResposta<ModeloMoto>> BuscarPorPlaca (string Placa);
        Task<ModeloDeResposta<List<ModeloMoto>>> CadastrarMoto(MotoCriaçaoDto motoCriaçãoDto);
        Task<ModeloDeResposta<List<ModeloMoto>>> EditarPlaca(MotoEdiçaoDto motoEdiçãoDto);
        Task<ModeloDeResposta<List<ModeloMoto>>> ExcluirMoto(int idMoto);




    }
}
