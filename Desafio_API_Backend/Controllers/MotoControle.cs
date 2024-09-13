using Desafio_API_Backend.Dto;
using Desafio_API_Backend.Modelos;
using Desafio_API_Backend.Serviços.Moto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoControle : ControllerBase
    {

        private readonly MotoInterface _motoInterface;
        public MotoControle(MotoInterface motoInterface) {

            _motoInterface = motoInterface;


        }




        [HttpPost("CadastrarMoto")]
        public async Task<ActionResult<ModeloDeResposta<List<ModeloMoto>>>> CadastrarMoto(MotoCriaçaoDto motoCriaçãoDto)
        {
            var motos = await _motoInterface.CadastrarMoto(motoCriaçãoDto);
            return Ok(motos);
        }





        [HttpGet("ListarTodasMotos")]
        public async Task<ActionResult<ModeloDeResposta<List<ModeloMoto>>>> ListarTodasMotos()
        {
            var Motos = await _motoInterface.ListarTodasMotos();
            return Ok(Motos);

        }

        [HttpGet("BuscarPorPlaca/{placa}")]
        public async Task<ActionResult<ModeloDeResposta<ModeloMoto>>> BuscarPorPlaca(string placa)
        {
            var Moto = await _motoInterface.BuscarPorPlaca(placa);
            return Ok(Moto);

        }


        [HttpPut("EditarPlaca")]
        public async Task<ActionResult<ModeloDeResposta<List<ModeloMoto>>>> EditarPlaca(MotoEdiçaoDto motoEdiçãoDto)
        {
            var motos = await _motoInterface.EditarPlaca(motoEdiçãoDto);
            return Ok(motos);
        }

        [HttpDelete("ExcluirMoto")]
        public async Task<ActionResult<ModeloDeResposta<List<ModeloMoto>>>> ExcluirMoto(int idMoto)
        {
            var motos = await _motoInterface.ExcluirMoto(idMoto);
            return Ok(motos);
        }


    }
}
