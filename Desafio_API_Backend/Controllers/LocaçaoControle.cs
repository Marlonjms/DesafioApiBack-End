using Desafio_API_Backend.Dto;
using Desafio_API_Backend.Dto_Moto.locaçao;
using Desafio_API_Backend.Modelos;
using Desafio_API_Backend.Serviços.Locacao;
using Desafio_API_Backend.Serviços.Moto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocaçaoControle : ControllerBase
    {

        private readonly LocaçaoInterface _locaçaoIntrtface;
        public LocaçaoControle(LocaçaoInterface locaçaoInterface)
        {

            _locaçaoIntrtface = locaçaoInterface;


        }




        [HttpPost("CadastraLocaçaoMoto")]
        public async Task<ActionResult<ModeloDeResposta<List<ModeloMoto>>>> CadastraLocaçaoMoto(LocaçaoCriaçaoDto locaçaoCriaçaoDto)
        {
            var Locações = await _locaçaoIntrtface.CadastrarLocacao(locaçaoCriaçaoDto);
            return Ok(Locações);
        }





    }
}
