using Desafio_API_Backend.Dto;
using Desafio_API_Backend.Dto_Moto.locaçao;
using Desafio_API_Backend.Modelos;

namespace Desafio_API_Backend.Serviços.Locacao
{
    public interface LocaçaoInterface
    {
        Task<ModeloDeResposta<List<ModeloLocaçao>>> CadastrarLocacao(LocaçaoCriaçaoDto locaçaoCriaçaoDto);
    }
}
